using MedicaERP.Web.Filters;
using MedicaERPMVC.Application.Interfaces;
using MedicaERPMVC.Application.ViewModels.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MedicaERP.Web.Controllers
{   [AllowAnonymous]
    public class PatientController : Controller
    {        //Pierwsza walidacja i przekazanie żadania do innej warstwy 
             // widok dla akcji
             //tabela z pacjentami
             // filtrowanie pacjentow
             //kryteria filtrow
             //przygotować dane przefiltrowane dla lekarza i dla pacjenta(dostepni lekarze w danej placówce
             //serwis przygotuje dane w odpowiednim formacie
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;
        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }
        //[CheckPermissions("Read")]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _patientService.GetAllPatientsForList(2, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize,int? numberOfPage,string stringToSearch)
        {
            if (!numberOfPage.HasValue)
            {
                numberOfPage = 1;
            }
            if (stringToSearch==null)
            {
                stringToSearch = string.Empty;
            }
            var model = _patientService.GetAllPatientsForList(pageSize, numberOfPage.Value, stringToSearch);
            return View(model);
        }

        public IActionResult ViewPatient(string patientId)
        {
            var idPatient = _patientService.GetPaitentById(patientId);
            return View();
        }
        
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult EditPatient(string id)
        {
            var patient = _patientService.GetPatientForEdit(id);
            return View(patient);
        }
        [HttpGet]
        public IActionResult AddPatient()
        {
            return View(new NewPatientViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPatient(NewPatientViewModel modelPatient)
        {
            if (ModelState.IsValid)//Dodac data adnotations
            {
                _patientService.UpdatePatient(modelPatient);
                return RedirectToAction("Index");// po wypelnieniu
            }
            return View(modelPatient);
        }
        public IActionResult Delete(string patientId)
        {
            _patientService.DeletePatient(patientId);
           return RedirectToAction("Index");
        }
    }
}
