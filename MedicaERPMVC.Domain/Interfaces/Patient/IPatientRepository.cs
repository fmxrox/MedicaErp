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
        IQueryable<UserOfClinic> GetAllPatients();
        UserOfClinic GetPatient(string id);
        string AddPatient(UserOfClinic patient);
        void UpdatePatient(UserOfClinic patient);
        void DeletePatient(string patientId);
    }
}
