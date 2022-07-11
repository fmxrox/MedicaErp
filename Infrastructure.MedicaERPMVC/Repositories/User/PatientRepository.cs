using MedicaERPMVC.Domain.Interface;
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

        public IQueryable<global::MedicaERPMVC.Domain.Model.Patient> GetAllPatients()
        {
            return _medicaDbContext.Patients.Where(p => p.isActivate && p.isPatient);
        }

        public global::MedicaERPMVC.Domain.Model.Patient GetPatient(int pesel)
        {
            return _medicaDbContext.Patients.FirstOrDefault(p => p.Id == pesel);
        }
    }
}
