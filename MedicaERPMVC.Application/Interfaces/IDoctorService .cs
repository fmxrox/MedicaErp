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
        ListPatientsForListViewModel GetAllDoctorsForList(int pageSize, int pageNumber, string stringToFind);
        int AddDoctor(NewDoctorViewModel newPatientViewModel);
        DoctorDetailsViewModel GetDoctorById(string doctorId);
        NewDoctorViewModel GetDoctorForEdit(string doctorId);
        DoctorDetailsViewModel GetDoctorDetails(string doctorId);
        void UpdateDoctor(NewDoctorViewModel doctorViewModel);
        void DeleteDoctor(string doctorId);
    }
}
