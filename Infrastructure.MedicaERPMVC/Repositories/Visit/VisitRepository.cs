using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Interfaces.Doctor;
using MedicaERPMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MedicaERPMVC.Repositories
{
    public class VisitRepository : IVisitRepository
    {


        private readonly MedicaErpDbContext _medicaErpDbContext;
        public VisitRepository(MedicaErpDbContext medicaErpDbContext)
        {
            _medicaErpDbContext = medicaErpDbContext;
        }

        public int AddVisit(Visit visit)
        {
            _medicaErpDbContext.Visits.Add(visit);
            _medicaErpDbContext.SaveChanges();
            return visit.Id;
        }
        public IQueryable<Visit> GetVisitsByTypeId(int typeId)
        {
            var visits = _medicaErpDbContext.Visits.Where(x => x.VisitTypeId == typeId)
                 .OrderByDescending(x => x.Date)
                .ThenByDescending(x => x.StartTime);
            return visits.AsQueryable();
        }
        public async Task<Visit> GetVisitById(int name)
        {
            var visit = await _medicaErpDbContext.Visits.FindAsync(name);
            if (visit == null) throw new Exception("Visit not found");
            return visit;
        }
        public void DeleteVisit(int idVisit)
        {

            var visit = _medicaErpDbContext.Visits.Find(idVisit);
            if (visit != null)
            {
                _medicaErpDbContext.Remove(visit);
                _medicaErpDbContext.SaveChanges();
            }
        }
        public void VisitEditAsync(Visit visit)           
        {
            _medicaErpDbContext.Attach(visit);
            _medicaErpDbContext.Entry(visit).Property("Description").IsModified = true;
            _medicaErpDbContext.Entry(visit).Property("StartTime").IsModified = true; 
            _medicaErpDbContext.Entry(visit).Property("EndTime").IsModified = true;
            _medicaErpDbContext.Entry(visit).Property("PatientId").IsModified = true;
            _medicaErpDbContext.Entry(visit).Property("DoctorId").IsModified = true;
            _medicaErpDbContext.Entry(visit).Property("Confirmed").IsModified = true;
              _medicaErpDbContext.Entry(visit).Property("IsDone").IsModified = true;
            _medicaErpDbContext.SaveChanges();         
    }

        public async Task<IQueryable<Visit>> GetVisitsToDo(string doctorId)
        {
            var presentDay = DateTime.Now.Date;
            var visits = await _medicaErpDbContext.Visits
                .Where(x => x.DoctorId == doctorId)
                .OrderByDescending(x => x.Date)
                .ThenByDescending(x=>x.StartTime)
                .ToListAsync();
            return visits.AsQueryable();
        }
        public IQueryable<Visit> GetAllVisits()
        {
            var visits= from c in _medicaErpDbContext.Visits.AsQueryable()
                   join u in _medicaErpDbContext.UserOfClinics.AsQueryable() on
                   c.DoctorId equals u.Id
                   select c;
            foreach (var vis in visits)
            {
                vis.Doctor = _medicaErpDbContext.UserOfClinics.Where(p=>p.Id == vis.DoctorId).FirstOrDefault();
                vis.Patient = _medicaErpDbContext.UserOfClinics.Where(p=>p.Id == vis.PatientId).FirstOrDefault();
            }
            return visits;
        }

    

    }
}
