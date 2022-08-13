using MedicaERPMVC.Domain.Interface;

namespace Infrastructure.MedicaERPMVC.Repositories.User
{
    using global::MedicaERPMVC.Domain.Model;
    public class PatientRepository : IPatientRepository
    {
        private readonly MedicaErpDbContext _medicaDbContext;

        public PatientRepository(MedicaErpDbContext medicaErpDbContext)
        {
            _medicaDbContext = medicaErpDbContext;
        }

        public string AddPatient(Patient patient)
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

        public IQueryable<Patient> GetAllPatients()
        {
            throw new NotImplementedException();
        }



        //public IQueryable<global::MedicaERPMVC.Domain.Model.Patient> GetAllPatients()
        //{
        //    return _medicaDbContext.Patients.Where(p => p.isActivate && p.isPatient);
        //}

        public Patient GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        //public global::MedicaERPMVC.Domain.Model.Patient GetPatient(int id)
        //{
        //    return _medicaDbContext.Patients.FirstOrDefault(p => p.Id == id);
        //}

        public void UpdatePatient(Patient patient)
        {
           _medicaDbContext.Attach(patient);
            _medicaDbContext.Entry(patient).Property("FirstName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("LastName").IsModified=true;
            _medicaDbContext.Entry(patient).Property("Pesel").IsModified=true;        
            _medicaDbContext.Entry(patient).Property("PhoneNumber").IsModified=true;        
            _medicaDbContext.SaveChanges();
        }

        int IPatientRepository.AddPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        //int IPatientRepository.AddPatient(global::MedicaERPMVC.Domain.Model.Patient patient)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
