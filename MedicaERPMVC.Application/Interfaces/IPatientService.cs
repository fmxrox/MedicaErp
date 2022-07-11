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
        int AddPatient(NewPatientViewModel newPatientViewModel);
        bool EditPatient(int patientId);
        PatientDetailsViewModel GetPaitentById(int PatientId);

        PatientDetailsViewModel GetPatientDetails(int PatientId);
    }
}
