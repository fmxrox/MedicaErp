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
        void DeleteVisit(int idVisit);
        Task<IEnumerable<Visit>> GetAllVisits();
        Task<Visit> GetVisitById(string name);
        IQueryable<Visit> GetVisitsByTypeId(int typeId);
        Task<IEnumerable<Visit>> GetVisitsToDo(string doctorId);
        Task VisitEditAsync(int userId, string name, string lastName, string? pesel, UserOfClinic Patient, Clinic Clinic, string description, bool isDone);

        //IQueryable<Visit> GetAllVisits();
        //Visit GetVisit(int id);
        //int AddVisit(Visit visit);
        //void UpdateVisit(Visit visit);
        //void DeletePatient(int visitId);
        //IQueryable<Visit> GetVisitForToday(int id);
        //IQueryable<Visit> GetUpcommingVisit(string userId);
        //IQueryable<Visit> FindVisits(string searchString);

    }
}
