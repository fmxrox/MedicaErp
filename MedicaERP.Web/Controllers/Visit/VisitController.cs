using MedicaERP.Web.Filters;
using MedicaERPMVC.Application.Services.Visit;
using MedicaERPMVC.Application.ViewModels.Visits;
using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicaERP.Web.Controllers
{
    public class VisitController : Controller
    {
        private readonly UserManager<UserOfClinic> _usersClinic;
        private readonly IVisitService _visitService;
        public VisitController(UserManager<UserOfClinic> usersClinic, IVisitService visitService)
        {
            _usersClinic = usersClinic;
            _visitService = visitService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [CheckPermissions("Read")]
        [HttpGet]
        public IActionResult VisitList(int pageSize, int numberOfPage, string stringToSearch)
        {
            var model = _visitService.GetAllVisitsForList(pageSize, numberOfPage, stringToSearch);
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? numberOfPage, string stringToSearch)
        {
            if (!numberOfPage.HasValue)
            {
                pageSize = 1;
            }
            if (stringToSearch == null)
            {
                stringToSearch = string.Empty;
            }
            var model = _visitService.GetAllVisitsForList(pageSize, numberOfPage.Value, stringToSearch);
            return View(model);
        }

        public async Task<IActionResult> AddVisit(string id)
        {
            var visit = new NewVisitViewModel
            {
                Id = id,

            };
            return View(visit);
        }
        [HttpPost]
        public async Task<IActionResult> AddVisit(NewVisitViewModel newvisitViewModel)
        {
            var patient = await _usersClinic.GetUserAsync(HttpContext.User);
            var patientId = await _usersClinic.GetUserIdAsync(patient);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddVisit");
            }
            _visitService.AddVisitAsync(newvisitViewModel);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> VisitToCancel(string id)
        {
            var visitCancel = _visitService.GetVisitId(id);

            if (visitCancel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(visitCancel);
        }
        [HttpPost]
        public async Task<IActionResult> VisitToCancelPost(string id)
        {
            _visitService.DeleteVisit(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> GetVisitForDoctor(int doCtorId, int pageSize, int pageNumber, string? stringToFind)
        {
            var visits = _visitService.GetNextVisitsForDoctorUpcoming(doCtorId, pageSize, pageNumber, stringToFind);
            return View(visits);

        }
        public async Task<IActionResult> GetUpcomingVisitForDoctor(int doCtorId, int pageSize, int pageNumber, string? stringToFind)
        {
            var visits = _visitService.GetNextVisitsForDoctorUpcoming(doCtorId, pageSize, pageNumber, stringToFind);
            return View(visits);

        }

    }
}
