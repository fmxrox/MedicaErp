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
            var visits = _medicaErpDbContext.Visits.Where(x => x.VisitTypeId == typeId);
            return visits;
        }
        public async Task<Visit> GetVisitById(string name)
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
        public async Task VisitEditAsync(int userId,
            string name,
            string lastName,
            string? pesel,
            UserOfClinic Patient,
            Clinic Clinic,
            string description,
            bool isDone
            )
        {
            var visitToEdit = await this._medicaErpDbContext.Visits.FindAsync(userId);
            if (visitToEdit == null)
                throw new Exception("Patient not found");
            visitToEdit.Patient = Patient;
            visitToEdit.Clinic = Clinic;
            visitToEdit.Description = description;
            visitToEdit.IsDone = isDone;
            _medicaErpDbContext.SaveChanges();
        }

        public async Task<IQueryable<Visit>> GetVisitsToDo(string doctorId)
        {
            var presentDay = DateTime.Now.Date;
            var visits = await _medicaErpDbContext.Visits
                .Where(x => x.DoctorId == doctorId && x.Date.Date >= presentDay
            && x.IsDone == false)
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
