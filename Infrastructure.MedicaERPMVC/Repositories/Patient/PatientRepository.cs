using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Interfaces;
using MedicaERPMVC.Domain.Model;

namespace Infrastructure.MedicaERPMVC.Repositories.User
{
    
    public class PatientRepository : IPatientRepository
    {
        private readonly MedicaErpDbContext _medicaDbContext;

        public PatientRepository(MedicaErpDbContext medicaErpDbContext)
        {
            _medicaDbContext = medicaErpDbContext;
        }

        public string AddPatient(UserOfClinic patient)
        {
          _medicaDbContext.UserOfClinic.Add(patient);
           _medicaDbContext.SaveChanges();
            return patient.Id;
        }

        public void DeletePatient(string patientId)
        {
            var patientToDelete = _medicaDbContext.UserOfClinic.Find(patientId);
            if (patientToDelete != null)
            {
                _medicaDbContext.UserOfClinic.Remove(patientToDelete);
                _medicaDbContext.SaveChanges();
            }
        }

        public IQueryable<UserOfClinic> GetAllPatients()
        {
            return _medicaDbContext.UserOfClinic.Where(x => x.IsPatient);
        }

        public UserOfClinic GetPatient(string id)
        {
            var patientToFind = _medicaDbContext.UserOfClinic.Find(id);
            if (patientToFind == null)
                throw new Exception("User not found");
             return patientToFind;
        }

        public void UpdatePatient(UserOfClinic patient)
        {
           _medicaDbContext.Attach(patient);
            _medicaDbContext.Entry(patient).Property("FirstName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("LastName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("Pesel").IsModified=true;        
            _medicaDbContext.Entry(patient).Property("PhoneNumber").IsModified=true;        
            _medicaDbContext.SaveChanges();
        }
    }
}
