
namespace MedicaERPMVC.Domain.Interfaces.Doctor
{
    using MedicaERPMVC.Domain.Model;

    public interface IDoctorRepository
    {
     
            IQueryable<Doctor> GetAllDoctors();
            Doctor GetDoctor(string id);
            int AddDoctor(Doctor doctor);
            void UpdateDoctor(Doctor patient);
            void DeleteDoctor(string patientId);
        
    }
}
