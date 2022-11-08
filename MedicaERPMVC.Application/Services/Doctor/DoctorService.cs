using AutoMapper;
using MedicaERPMVC.Application.ViewModels.Patient;
using MedicaERPMVC.Domain.Interfaces.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicaERPMVC.Domain.Model;
using AutoMapper.QueryableExtensions;

namespace MedicaERPMVC.Application.Services.Doctor
{
    public class DoctorService : IDoctorService
    {
        //wszystkie polaczena caly kod odp za reagowanie na zadania uzytkownika
        //w repozytorium oczekujemy konkretnego przedmiotu(ty tylko check czy null)
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public int AddPatient(NewDoctorViewModel newPatientViewModel)
        {

            var doctor = _mapper.Map<MedicaERPMVC.Domain.Model.Doctor>(newPatientViewModel);
            var id = _doctorRepository.AddDoctor(doctor);
            return id;
        }

        public void DeletePatient(string doctorId)
        {
            _doctorRepository.DeleteDoctor(doctorId);
        }

        public ListDoctorsForListViewModel GetAllPatientsForList(int pageSize, int pageNumber, string stringToFind)
        {
            var doctors = _doctorRepository.GetAllDoctors()
                .ProjectTo<DoctorForListVM>(_mapper.ConfigurationProvider).ToList();/*||p.FirstName.StartsWith(stringToFind)|| p.Pesel.StartsWith(stringToFind))*/// PROJECT DO IQeryable do pojedynczyc <Map>

            var patientsFinally = doctors.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var doctorsForListViewModel = new ListDoctorsForListViewModel()
            {
                Doctors = doctors,
                Count = doctors.Count(),
                PageSize = pageSize,
                ActualPage = pageNumber,
                StringToSearch = stringToFind
            };
            return doctorsForListViewModel;
        }

        public DoctorDetailsViewModel GetDoctorById(string DoctorId)
        {
            var doctor = _doctorRepository.GetDoctor(DoctorId);
            var doctorVm = _mapper.Map<DoctorDetailsViewModel>(doctor);
            return doctorVm;
        }

        public DoctorDetailsViewModel GetDoctorDetails(string doctorId)
        {
            var doctor = _doctorRepository.GetDoctor(doctorId);
            var doctorDetailsViewModel = _mapper.Map<DoctorDetailsViewModel>(doctor);
            return doctorDetailsViewModel;
        }

        public NewDoctorViewModel GetPatientForEdit(string doctorId)
        {
            var doctor = _doctorRepository.GetDoctor(doctorId);
            var doctorViewModel = _mapper.Map<NewDoctorViewModel>(doctor);
            return doctorViewModel;
        }

        public void UpdatePatient(NewDoctorViewModel doctorViewModel)
        {
            var doctor = _mapper.Map<MedicaERPMVC.Domain.Model.Doctor>(doctorViewModel);
            _doctorRepository.UpdateDoctor(doctor);
        }
    }
}
