using MedicaERPMVC.Application.Interfaces;
using MedicaERPMVC.Application.ViewModels.Patient;
using MedicaERPMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.Services
{
    public class PatientService : IPatientService
    {
        //wszystkie polaczena caly kod odp za reagowanie na zadania uzytkownika
        //w repozytorium oczekujemy konkretnego przedmiotu(ty tylko check czy null)
        private readonly IPatientRepository _patientRepository;
        public int AddPatient(NewPatientViewModel newPatientViewModel)
        {
            throw new NotImplementedException();
        }

        public bool EditPatient(int patientId)
        {
            throw new NotImplementedException();
        }

        public ListPatientsForListViewModel GetAllPatientsForList()
        {
            var patients = _patientRepository.GetAllPatients();
            ListPatientsForListViewModel result = new ListPatientsForListViewModel();
            result.Patients = new List<PatientForListViewModel>();
            foreach (var pat in patients)
            {
                var patientViewModel = new PatientForListViewModel()
                {
                    Id = pat.ID,
                    Name = pat.UserName,
                    Pesel = pat.Pesel,
                    DateOfBirth = pat.DateOfBirth,
                    Sex = pat.Sex
                };
                result.Patients.Add(patientViewModel);
            }
            result.Count = result.Patients.Count;
            return result;
        }

        public PatientDetailsViewModel GetPaitentById(int PatientId)
        {
            throw new NotImplementedException();
        }

        public PatientDetailsViewModel GetPatientDetails(int PatientId)
        { 
            var patient = _patientRepository.GetPatient(PatientId);
            var patientViewModel = new PatientDetailsViewModel();
            patientViewModel.Id = patient.ID;
            patientViewModel.FullName = patient.FirstName + " " + patient.LastName;
            patientViewModel.Pesel = patient.Pesel;
            var contactInformation = patient.UserContactInformation;
            patientViewModel.UserContactInformation = new UserContactInformationForViewModel
            {
                Adress = contactInformation.Adress,
                PhoneNumber = contactInformation.PhoneNumber

            };
            return patientViewModel;
        }
    }
}
