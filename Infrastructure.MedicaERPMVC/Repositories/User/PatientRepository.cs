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

        public IQueryable<global::MedicaERPMVC.Domain.Model.User> GetAllPatients()
        {
            throw new NotImplementedException();
        }

        public global::MedicaERPMVC.Domain.Model.User GetPatient(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
