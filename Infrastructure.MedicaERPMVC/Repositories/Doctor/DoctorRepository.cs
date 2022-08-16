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
    public int AddDoctor(UserOfClinic doctor)
    {
      _medicaErpDbContext.UserOfClinic.Add(doctor);
        _medicaErpDbContext.SaveChanges();
        return 1;
    }

    public void DeleteDoctor(string patientId)
    {
        var doctorToDelete = _medicaErpDbContext.UserOfClinic.Find(patientId);
        if (doctorToDelete != null)
        {
            _medicaErpDbContext.UserOfClinic.Remove(doctorToDelete);
            _medicaErpDbContext.SaveChanges();
        }
    }

    public IQueryable<UserOfClinic> GetAllDoctors()
    {
        var doctors = _medicaErpDbContext.UserOfClinic.Where(x => x.isDoctor);
        return doctors;      
    }

    public UserOfClinic GetDoctor(string id)
    {
        var doctorToFind = _medicaErpDbContext.UserOfClinic.Find(id);
        if (doctorToFind == null)
            throw new Exception("User not found");
        return doctorToFind;
    }

    public void UpdateDoctor(UserOfClinic doctor)
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
