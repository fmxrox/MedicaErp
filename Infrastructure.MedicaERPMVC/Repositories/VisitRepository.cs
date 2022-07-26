using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MedicaERPMVC.Repositories
{
    public class VisitRepository
    {// todo GetVisitByDoctorId or Something, po nr pesel
     //edit visit, update exception, Async wszędzie
     // po pesel whehe visit inprogress- something like that
     //Edit async
     //RESX- tłumaczenie


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
        public  IQueryable<Visit> GetVisitsByTypeId(int typeId)
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
            string? pesel)
        {
            var userToEdit = await this._medicaErpDbContext.Patients.FindAsync(userId);
            if (userToEdit == null)
                throw new Exception("User not found");
            userToEdit.FirstName = name;
            userToEdit.LastName = lastName;
            if (pesel!=null)
                userToEdit.Pesel = pesel;
            _medicaErpDbContext.SaveChanges();
        }

    }
}
