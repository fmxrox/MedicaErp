using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MedicaERPMVC.Repositories.User
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedicaErpDbContext _medicaDbContext;

        public PatientRepository(MedicaErpDbContext medicaErpDbContext)
        {
            _medicaDbContext = medicaErpDbContext;
        }

        public string AddPatient(global::MedicaERPMVC.Domain.Model.User patient)
        {
          _medicaDbContext.Patients.Add(patient);
           _medicaDbContext.SaveChanges();
            return patient.Id;
        }

        public void DeletePatient(int patientId)
        {
            var patientToDelete = _medicaDbContext.Patients.Find(patientId);
            if (patientToDelete != null)
            {
                _medicaDbContext.Patients.Remove(patientToDelete);
                _medicaDbContext.SaveChanges();
            }
        }
            
            

        public IQueryable<global::MedicaERPMVC.Domain.Model.User> GetAllPatients()
        {
            return _medicaDbContext.Patients.Where(p => p.isActivate && p.isPatient);
        }

        public global::MedicaERPMVC.Domain.Model.User GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        //public global::MedicaERPMVC.Domain.Model.User GetPatient(int id)
        //{
        //    return _medicaDbContext.Patients.FirstOrDefault(p => p.Id == id);
        //}

        public void UpdatePatient(global::MedicaERPMVC.Domain.Model.User patient)
        {
           _medicaDbContext.Attach(patient);
            _medicaDbContext.Entry(patient).Property("FirstName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("LastName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("Pesel").IsModified=true;        
            _medicaDbContext.Entry(patient).Property("PhoneNumber").IsModified=true;        
            _medicaDbContext.SaveChanges();
        }

        int IPatientRepository.AddPatient(global::MedicaERPMVC.Domain.Model.User patient)
        {
            throw new NotImplementedException();
        }
    }
}
