using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;
        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
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
            var patients = _patientRepository.GetAllPatients()// PROJECT DO IQeryable do pojedynczyc <Map>
                .ProjectTo<PatientForListViewModel>(_mapper.ConfigurationProvider).ToList();

            var patientsForListViewModel = new ListPatientsForListViewModel()
            {
                Patients = patients,
                Count = patients.Count()
            };
            return patientsForListViewModel;
        }

        public PatientDetailsViewModel GetPaitentById(int PatientId)
        {
            throw new NotImplementedException();
        }

        public PatientDetailsViewModel GetPatientDetails(int PatientId)
        { 
            var patient = _patientRepository.GetPatient(PatientId);
            var patientDetailsViewModel = _mapper.Map<PatientDetailsViewModel>(patient);
            return patientDetailsViewModel;
        }
    }
}
