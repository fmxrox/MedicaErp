using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace MedicaERP.Web.Controllers
{
    public class PatientController : Controller
    {        //Pierwsza walidacja i przekazanie żadania do innej warstwy 
             // widok dla akcji
             //tabela z pacjentami
             // filtrowanie pacjentow
             //kryteria filtrow
             //przygotować dane przefiltrowane dla lekarza i dla pacjenta(dostepni lekarze w danej placówce
             //serwis przygotuje dane w odpowiednim formacie
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    var model = patientService.GetAllPatientsForList();
        //    return View(model);
        //}
        //[HttpGet]
        //public IActionResult AddPatient()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddPatient(PatientModel modelPatient)
        //{
        //    var idPatient = patientService.AddPatient(modelPatient);
        //    return View();// po wypelnieniu
        //}
        //[HttpGet]
        //public IActionResult AddAdress(int patientId)
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddAdress(AdressModel modelPatientAdress)
        //{
        //    var idPatient = patientService.AddAdress(modelPatientAdress);
        //    return View();// po wypelnieniu
        //}

        //public IActionResult ViewPatient(int patientId)
        //{
        //    var idPatient = patientService.GetPaitentById(patientId);
        //}
    }
}
