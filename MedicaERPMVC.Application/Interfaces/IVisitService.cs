using MedicaERPMVC.Application.ViewModels.Visits;

namespace MedicaERPMVC.Application.Services.Visit
{
    public interface IVisitService
    {
        int AddVisitAsync(NewVisitViewModel newVisitViewModel);
        void DeleteVisit(int id);
        Task<ListVisitsViewModel> GetAllVisitsForDoctor(string doCtorId, int pageSize, int pageNumber, string stringToFind);
        Task<IQueryable<VisitViewModel>> GetAllVisitsForList(int pageSize, int pageNumber, string stringToFind);
        Task<ListVisitsViewModel> GetNextVisitsForDoctorUpcoming(string doCtorId, int pageSize, int pageNumber, string stringToFind);
    }
}