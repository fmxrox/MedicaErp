using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedicaERPMVC.Application.Interfaces;
using MedicaERPMVC.Application.ViewModels.Patient;
using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Interfaces;
using MedicaERPMVC.Domain.Model;
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
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public string AddPatient(NewPatientViewModel newPatientViewModel)
        {
           
            var patient = _mapper.Map<UserOfClinic>(newPatientViewModel);
            var id = _patientRepository.AddPatient(patient);
            return id;
        }

        public void DeletePatient(string patientId)
        {
            _patientRepository.DeletePatient(patientId);
        }

        public ListPatientsForListViewModel GetAllPatientsForList(int pageSize, int pageNumber, string stringToFind)
        {

            //var patients = _patientRepository.GetAllPatients();
            //ListPatientsForListViewModel patientsListVM = new ListPatientsForListViewModel();
            //patientsListVM.Patients = new List<PatientForListViewModel>();
            //foreach (var pat in patients)
            //{
            //    var patientVm = new PatientForListViewModel()
            //    {
            //        Name = pat.FirstName,
            //        LastName = pat.LastName,
            //        Pesel = pat.Pesel,
            //        PhoneNumber = pat.PhoneNumber
            //    };
            //    patientsListVM.Patients.Add(patientVm);
            //}
            //patientsListVM.Count=patientsListVM.Patients.Count;
            //return patientsListVM;



            var patients = _patientRepository.GetAllPatients().Where(x=>x.LastName.StartsWith(stringToFind)).ProjectTo<PatientForListViewModel>(_mapper.ConfigurationProvider).ToList();/*||p.FirstName.StartsWith(stringToFind)|| p.Pesel.StartsWith(stringToFind))*/// PROJECT DO IQeryable do pojedynczyc <Map>
            if (patients == null)
            {
                throw new Exception("Empty list");
            }
            var patientsFinally = patients.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var patientsForListViewModel = new ListPatientsForListViewModel()
            {
                Patients = patients,
                Count = patients.Count(),
                PageSize = pageSize,
                ActualPage = pageNumber,
                StringToSearch = stringToFind
            };
            return patientsForListViewModel;
        }
   
        public PatientDetailsViewModel GetPaitentById(string PatientId)
        {
            var patient = _patientRepository.GetPatient(PatientId);
            var patientDetailsViewModel = _mapper.Map<PatientDetailsViewModel>(patient);
            return patientDetailsViewModel;
        }

        public PatientDetailsViewModel GetPatientDetails(string PatientId)
        { 
            var patient = _patientRepository.GetPatient(PatientId);
            var patientDetailsViewModel = _mapper.Map<PatientDetailsViewModel>(patient);
            return patientDetailsViewModel;
        }

        public NewPatientViewModel GetPatientForEdit(string PatientId)
        {
            var patient = _patientRepository.GetPatient(PatientId);
            var patientsViewModel = _mapper.Map<NewPatientViewModel>(patient);
            return patientsViewModel;
        }

        public void UpdatePatient(NewPatientViewModel patientViewModel)
        {
           var patient = _mapper.Map<UserOfClinic>(patientViewModel);
            _patientRepository.UpdatePatient(patient);     
        }
    }
}
