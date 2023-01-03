using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MedicaERPMVC.Repositories.Admin
{
    public class AdminRepository
    {
        private readonly MedicaErpDbContext _medicaDbContext;
        public AdminRepository(MedicaErpDbContext dbContext)
        {
            _medicaDbContext = dbContext;
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
        public void UpdatePatient(global::MedicaERPMVC.Domain.Model.UserOfClinic patient)
        {
            _medicaDbContext.Attach(patient);
            _medicaDbContext.Entry(patient).Property("FirstName").IsModified = true;
            _medicaDbContext.Entry(patient).Property("LastName").IsModified = true;
            _medicaDbContext.Entry(patient).Property("Pesel").IsModified = true;
            _medicaDbContext.Entry(patient).Property("PhoneNumber").IsModified = true;
            _medicaDbContext.SaveChanges();
        }
        public int AddDoctor(UserOfClinic doctor)
        {
            _medicaDbContext.Doctors.Add(doctor);
            _medicaDbContext.SaveChanges();
            return 1;
        }

        public void DeleteDoctor(string patientId)
        {
            var doctorToDelete = _medicaDbContext.Doctors.Find(patientId);
            if (doctorToDelete != null)
            {
                _medicaDbContext.Doctors.Remove(doctorToDelete);
                _medicaDbContext.SaveChanges();
            }
        }

        public void UpdateDoctor(UserOfClinic doctor)
        {
            _medicaDbContext.Attach(doctor);
            _medicaDbContext.Entry(doctor).Property("FirstName").IsModified = true;
            _medicaDbContext.Entry(doctor).Property("LastName").IsModified = true;
            _medicaDbContext.Entry(doctor).Property("Pesel").IsModified = true;
            _medicaDbContext.Entry(doctor).Property("PhoneNumber").IsModified = true;
            _medicaDbContext.Entry(doctor).Property("RoleOfUser").IsModified = true;
            _medicaDbContext.Entry(doctor).Property("isDoctor").IsModified = true;
            _medicaDbContext.SaveChanges();
        }

    }
}
