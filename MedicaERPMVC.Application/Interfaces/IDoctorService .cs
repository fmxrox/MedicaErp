using MedicaERPMVC.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.Interfaces
{
   public interface IDoctorService
    {
        int AddPatient(NewDoctorViewModel newPatientViewModel);
        void DeletePatient(string doctorId);
        ListDoctorsForListViewModel GetAllPatientsForList(int pageSize, int pageNumber, string stringToFind);
        List<DoctorForListVM> GetAllDoctorsAll();
        DoctorDetailsViewModel GetDoctorById(string DoctorId);
        DoctorDetailsViewModel GetDoctorDetails(string doctorId);
        NewDoctorViewModel GetPatientForEdit(string doctorId);
        void UpdatePatient(NewDoctorViewModel doctorViewModel);
    }
}
