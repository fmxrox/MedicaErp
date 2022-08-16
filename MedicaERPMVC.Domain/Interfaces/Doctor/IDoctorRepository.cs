using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Interfaces.Doctor
{
    public interface IDoctorRepository
    {
     
            IQueryable<UserOfClinic> GetAllDoctors();
            UserOfClinic GetDoctor(string id);
            int AddDoctor(UserOfClinic doctor);
            void UpdateDoctor(UserOfClinic patient);
            void DeleteDoctor(string patientId);
        
    }
}
