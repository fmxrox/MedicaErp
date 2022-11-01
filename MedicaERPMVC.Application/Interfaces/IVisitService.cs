using MedicaERPMVC.Application.ViewModels.Visits;

namespace MedicaERPMVC.Application.Services.Visit
{
    public interface IVisitService
    {
        int AddVisitAsync(NewVisitViewModel newVisitViewModel);
        void DeleteVisit(string id);
        Task<ListVisitsViewModel> GetAllVisitsForDoctor(int doCtorId, int pageSize, int pageNumber, string stringToFind);
        Task<IQueryable<VisitViewModel>> GetAllVisitsForList(int pageSize, int pageNumber, string stringToFind);
        Task<ListVisitsViewModel> GetNextVisitsForDoctorUpcoming(int doCtorId, int pageSize, int pageNumber, string stringToFind);
        Task<VisitViewModel> GetVisitId(string id);
    }
}