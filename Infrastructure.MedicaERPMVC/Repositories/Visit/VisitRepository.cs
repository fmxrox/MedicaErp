using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Interfaces.Doctor;
using MedicaERPMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MedicaERPMVC.Repositories
{
    public class VisitRepository : IVisitRepository
    {// todo GetVisitByDoctorId or Something, po nr pesel
     //edit visit, update exception, Async wszędzie
     // po pesel whehe visit inprogress- something like that
     //Edit async
     //RESX- tłumaczenie
     //FIND VISITS


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
            return visits;
        }
        public async Task<Visit> GetVisitById(int name)
        {
            var visit = await _medicaErpDbContext.Visits.FindAsync(name);
            if (visit == null) throw new Exception("Visit not found");
            return visit;
        }
        public void DeleteVisit(string idVisit)
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
            _medicaErpDbContext.Entry(visit).Property("Description").IsModified = true; _medicaErpDbContext.Entry(visit).Property("StartTime").IsModified = true; _medicaErpDbContext.Entry(visit).Property("EndTime").IsModified = true; _medicaErpDbContext.Entry(visit).Property("PatientId").IsModified = true; _medicaErpDbContext.Entry(visit).Property("DoctorId").IsModified = true; _medicaErpDbContext.Entry(visit).Property("VisitTypeId").IsModified = true; _medicaErpDbContext.Entry(visit).Property("Confirmed").IsModified = true;
              _medicaErpDbContext.Entry(visit).Property("IsDone").IsModified = true;
            _medicaErpDbContext.SaveChanges();         
    }

        public async Task<IQueryable<Visit>> GetVisitsToDo(string doctorId)
        {
            var presentDay = DateTime.Now.Date;
            var visits = await _medicaErpDbContext.Visits
                .Where(x => x.DoctorId == doctorId && x.Date.Date >= presentDay
            && x.IsDone == false)
                .OrderByDescending(x => x.Date)
                .ThenByDescending(x=>x.StartTime)
                .ToListAsync();
            return visits.AsQueryable();
        }
        public async Task<IQueryable<Visit>> GetAllVisits()
        {
            var visits = await _medicaErpDbContext.Visits.ToListAsync();
            return visits.AsQueryable();
        }

    

    }
}
