using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Interface
{
    public interface IVisitRepository
    {
        IQueryable<Visit> GetAllVisits();
        Visit GetVisit(int id);
        int AddVisit(Visit visit);
        void UpdateVisit(Visit visit);
        void DeletePatient(int visitId);
        IQueryable<Visit> GetVisitForToday(int id);
        IQueryable<Visit> GetUpcommingVisit(string userId);
        IQueryable<Visit> FindVisits(string searchString);

    }
}
