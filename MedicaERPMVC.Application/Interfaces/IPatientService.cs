using MedicaERPMVC.Application.ViewModels.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.Interfaces
{
   public interface IPatientService
    {
        ListPatientsForListViewModel GetAllPatientsForList(int pageSize, int pageNumber, string stringToFind);
        string AddPatient(NewPatientViewModel newPatientViewModel);
        PatientDetailsViewModel GetPaitentById(string PatientId);
        NewPatientViewModel GetPatientForEdit(string PatientId);
        PatientDetailsViewModel GetPatientDetails(string PatientId);
        void UpdatePatient(NewPatientViewModel patientViewModel);
        void DeletePatient(string patientId);
    }
}
