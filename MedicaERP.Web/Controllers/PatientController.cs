﻿using MedicaERPMVC.Application.Interfaces;
using MedicaERPMVC.Application.ViewModels.Patient;
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
        private readonly IPatientService _patientService;
        public PatientController(ILogger<PatientController> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }
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
                pageSize = 1;
            }
            if (stringToSearch==null)
            {
                stringToSearch = string.Empty;
            }
            var model = _patientService.GetAllPatientsForList(pageSize, numberOfPage.Value, stringToSearch);
            return View(model);
        }
        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(NewPatientViewModel modelPatient)
        {
            var idPatient = _patientService.AddPatient(modelPatient);
            return View();// po wypelnieniu
        }
        [HttpGet]
        public IActionResult AddAdress(int patientId)
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAdress(UserContactInformationForViewModel modelPatientAdress)
        {
            
            return View();// po wypelnieniu
        }

        public IActionResult ViewPatient(int patientId)
        {
            var idPatient = _patientService.GetPaitentById(patientId);
            return View();
        }
    }
}
