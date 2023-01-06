using MedicaERP.Web.Filters;
using MedicaERPMVC.Application.Interfaces;
using MedicaERPMVC.Application.Services.Visit;
using MedicaERPMVC.Application.ViewModels.Visits;
using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace MedicaERP.Web.Controllers
{
    public class VisitController : Controller
    {       
        private readonly IVisitService _visitService;
        private readonly IDoctorService _doctorService;
        private readonly UserManager<IdentityUser> _userOfClinic;
        public VisitController(IDoctorService doctorService, IVisitService visitService, UserManager<IdentityUser> UserOfClinic)
        {
            _doctorService = doctorService;
            _visitService = visitService;
            _userOfClinic = UserOfClinic;
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

        public IActionResult AddVisit()
        {
            var doctorsiSavaiable = _doctorService.GetAllDoctorsAll();
            var selectedDoctors = doctorsiSavaiable.Select(drs=> new SelectListItem
            {
                Text = $"Dr. {drs.Name+" "+ drs.LastName}",
                Value = drs.Id

            })
           .ToList();

            return View(new VisitViewModel
            {
                Date = System.DateTime.Now,
                Doctors = selectedDoctors
            });

        }
        [HttpPost]
        public async Task<IActionResult> AddVisit(NewVisitViewModel newvisitViewModel)
        {
            var visit = _visitService.AddVisitAsync(newvisitViewModel);
            return RedirectToAction("Index");
            if(ModelState.IsValid==false)
            {
                var doctors =await SelectedDoctorsList();
                newvisitViewModel.Doctors = (System.Collections.Generic.IEnumerable<SelectListItem>)doctors;
                return View(newvisitViewModel);
            }


            var isPossibleMakeVisit =await  _visitService.IsVisitPossible(
                newvisitViewModel.DoctorId,
                newvisitViewModel.Date,
                newvisitViewModel.StartTime);


            if (isPossibleMakeVisit == false)
            {
                var doctorsav =await SelectedDoctorsList();
                newvisitViewModel.Doctors = doctorsav;
                return View(newvisitViewModel);
            }
            var user = await this._userOfClinic.GetUserAsync(HttpContext.User);
            _visitService.AddVisitAsync(newvisitViewModel);

            TempData["Sucess"] = "You added new appoitment";
            return RedirectToAction("Index");
           
            //var isThisDoctorWorkinThisTime = 
        }

        private async Task<IEnumerable<SelectListItem>> SelectedDoctorsList()
        {
            var doctorsiSavaiable = _doctorService.GetAllDoctorsAll();
            var selectedDoctors = doctorsiSavaiable.Select(drs => new SelectListItem
            {
                Text = $"Dr. {drs.Name + " " + drs.LastName}",
                Value = drs.Id

            })
           .ToList();

            return selectedDoctors;
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
        public async Task<IActionResult> GetVisitForDoctor(string doCtorId, int pageSize, int pageNumber, string? stringToFind)
        {
            var visits = _visitService.GetNextVisitsForDoctorUpcoming(doCtorId, pageSize, pageNumber, stringToFind);
            return View(visits);

        }
        public async Task<IActionResult> GetUpcomingVisitForDoctor(string doCtorId, int pageSize, int pageNumber, string? stringToFind)
        {
            var visits = _visitService.GetNextVisitsForDoctorUpcoming(doCtorId, pageSize, pageNumber, stringToFind);
            return View(visits);

        }

    }
}
