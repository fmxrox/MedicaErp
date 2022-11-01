using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Interfaces
{
    public interface IPatientRepository
    {
        IQueryable<User> GetAllPatients();
        User GetPatient(string id);
        string AddPatient(User patient);
        void UpdatePatient(User patient);
        void DeletePatient(string patientId);
    }
}
