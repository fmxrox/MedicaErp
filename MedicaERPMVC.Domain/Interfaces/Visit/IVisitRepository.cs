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
        int AddVisit(Visit visit);
        void DeleteVisit(string idVisit);
        Task<IQueryable<Visit>> GetAllVisits();
        Task<Visit> GetVisitById(int name);
        IQueryable<Visit> GetVisitsByTypeId(int typeId);
        Task<IQueryable<Visit>> GetVisitsToDo(string doctorId);
        void VisitEditAsync(Visit visit);
    }
}
