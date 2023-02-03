using MedicaERPMVC.Application.Interfaces;
using MedicaERPMVC.Application.Services.Visit;
using MedicaERPMVC.Application.ViewModels.Doctor;
using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedicaERP.Web.Controllers.Doctors
{
    public class DoctorController : Controller
    {
        private readonly IVisitService _visitService;
        private readonly UserManager<UserOfClinic> _userManager;
        public DoctorController(IVisitService visitService, UserManager<UserOfClinic> userManager)
        {
            _visitService = visitService;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> DailyScheduleForDoctor(int pageSize, int? numberOfPage, string stringToSearch, DateTime date)
        {
            var currentDoctor = await this._userManager.GetUserAsync(HttpContext.User);
            if (!numberOfPage.HasValue)
            {
                numberOfPage = 1;
            }
            if (stringToSearch == null)
            {
                stringToSearch = string.Empty;
            }
        date = DateTime.Today;
            var visits = await _visitService.GetAllVisitsForDoctorToday(currentDoctor.Id, pageSize, numberOfPage.Value, stringToSearch, date);

            var model = new DailySchemeDoctorViewModel
            {
                Date = System.DateTime.Today,
                Visits = visits.Visits
            };

            return View(model);

        }

        [HttpPost]
        public IActionResult DailyScheduleForDoctor(DailySchemeDoctorViewModel model)
            => RedirectToAction(nameof(DailyScheduleForDoctor), model.Date);
    }
}
