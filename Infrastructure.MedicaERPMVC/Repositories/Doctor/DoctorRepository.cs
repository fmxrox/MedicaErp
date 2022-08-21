using MedicaERPMVC.Domain.Interfaces;
using MedicaERPMVC.Domain.Interfaces.Doctor;
using MedicaERPMVC.Domain.Model;

namespace Infrastructure.MedicaERPMVC.Repositories;

public class DoctorRepository : IDoctorRepository
{
    //czy dodowac IDoctor czy usero ograniczyć i rozszerzac jednoczesnie
    // tzn na konkraktach to zrobic
    private readonly MedicaErpDbContext _medicaErpDbContext;
    public DoctorRepository(MedicaErpDbContext medicaErpDbContext)
    {
        _medicaErpDbContext = medicaErpDbContext;
    }
    public int AddDoctor(Doctor doctor)
    {
      _medicaErpDbContext.Doctors.Add(doctor);
        _medicaErpDbContext.SaveChanges();
        return 1;
    }

    public void DeleteDoctor(string patientId)
    {
        var doctorToDelete = _medicaErpDbContext.Doctors.Find(patientId);
        if (doctorToDelete != null)
        {
            _medicaErpDbContext.Doctors.Remove(doctorToDelete);
            _medicaErpDbContext.SaveChanges();
        }
    }

    public IQueryable<Doctor> GetAllDoctors()
    {
        var doctors = _medicaErpDbContext.Doctors.Where(x => x.isDoctor);
        return doctors;      
    }

    public Doctor GetDoctor(string id)
    {
        var doctorToFind = _medicaErpDbContext.Doctors.Find(id);
        if (doctorToFind == null)
            throw new Exception("User not found");
        return doctorToFind;
    }

    public void UpdateDoctor(Doctor doctor)
    {
        _medicaErpDbContext.Attach(doctor);
        _medicaErpDbContext.Entry(doctor).Property("FirstName").IsModified = true;
        _medicaErpDbContext.Entry(doctor).Property("LastName").IsModified = true;
        _medicaErpDbContext.Entry(doctor).Property("Pesel").IsModified = true;
        _medicaErpDbContext.Entry(doctor).Property("PhoneNumber").IsModified = true;
        _medicaErpDbContext.Entry(doctor).Property("RoleOfUser").IsModified = true;
        _medicaErpDbContext.Entry(doctor).Property("isDoctor").IsModified = true;
        _medicaErpDbContext.SaveChanges();
    }
}
