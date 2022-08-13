using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Interface
{
    public interface IPatientRepository
    {
        IQueryable<Patient> GetAllPatients();
        Patient GetPatient(int id);
        int AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int patientId);
    }
}
