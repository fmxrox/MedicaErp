
namespace MedicaERPMVC.Domain.Interfaces.Doctor
{
    using MedicaERPMVC.Domain.Model;

    public interface IDoctorRepository
    {
     
            IQueryable<UserOfClinic> GetAllDoctors();
            UserOfClinic GetDoctor(string id);
            int AddDoctor(UserOfClinic doctor);
            void UpdateDoctor(UserOfClinic patient);
            void DeleteDoctor(string patientId);
        
    }
}
