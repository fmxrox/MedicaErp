using MedicaERP.Web.Filters;
using MedicaERPMVC.Application.Services.Visit;
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
        public IActionResult VisitList()
        {
            var model = _visitService.GetAllVisitsForList(2, 1, "");
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

        public async Task<IActionResult> AddVisit()
    }
}
