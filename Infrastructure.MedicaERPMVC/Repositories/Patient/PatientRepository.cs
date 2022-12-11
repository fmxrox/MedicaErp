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

        public string AddPatient(global::MedicaERPMVC.Domain.Model.UserOfClinic patient)
        {
          _medicaDbContext.UserOfClinics.Add(patient);
           _medicaDbContext.SaveChanges();
            return patient.Id;
        }

        public void DeletePatient(string patientId)
        {
            var patientToDelete = _medicaDbContext.Users.Find(patientId);
            if (patientToDelete != null)
            {
                _medicaDbContext.Users.Remove(patientToDelete);
                _medicaDbContext.SaveChanges();
            }
        }

        public IQueryable<global::MedicaERPMVC.Domain.Model.UserOfClinic> GetAllPatients()
        {
            var patients = _medicaDbContext.UserOfClinics;
            if (patients == null)
                throw new Exception("Patienst not found");
            return patients;
        }

        public global::MedicaERPMVC.Domain.Model.UserOfClinic GetPatient(string id)
        {
            var patientToFind = _medicaDbContext.UserOfClinics.Find(id);
            if (patientToFind == null)
                throw new Exception("UserOfClinic not found");
             return patientToFind;
        }

        public void UpdatePatient(global::MedicaERPMVC.Domain.Model.UserOfClinic patient)
        {
           _medicaDbContext.Attach(patient);
            _medicaDbContext.Entry(patient).Property("FirstName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("LastName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("Pesel").IsModified=true;        
            _medicaDbContext.Entry(patient).Property("PhoneNumber").IsModified=true;
            _medicaDbContext.Entry(patient).Property("isDoctor").IsModified = true;
            _medicaDbContext.Entry(patient).Property("isEmployee").IsModified = true;
            _medicaDbContext.Entry(patient).Property("isActivate").IsModified = true;
            _medicaDbContext.Entry(patient).Property("isEmployee").IsModified = true;
            _medicaDbContext.SaveChanges();
        }
    }
}
