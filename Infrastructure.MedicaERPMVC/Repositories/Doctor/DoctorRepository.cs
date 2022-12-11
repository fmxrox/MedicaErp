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
      _medicaErpDbContext.UserOfClinics.Add(doctor);
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

    public IQueryable<UserOfClinic> GetAllDoctors()
    {
        var doctors = _medicaErpDbContext.UserOfClinics.Where(x => x.isDoctor);
        if (doctors == null)
            throw new Exception("List doctors is empty");
        return doctors;      
    }

    public UserOfClinic GetDoctor(string id)
    {
        var doctorToFind = _medicaErpDbContext.UserOfClinics
            .Where(x => x.isDoctor == true && x.Id == id);
       
        if (doctorToFind == null)
            throw new Exception("UserOfClinic not found");
        return (UserOfClinic)doctorToFind;
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
        _medicaErpDbContext.Entry(doctor).Property("Descritpion").IsModified = true;
    _medicaErpDbContext.SaveChanges();
    }
}
