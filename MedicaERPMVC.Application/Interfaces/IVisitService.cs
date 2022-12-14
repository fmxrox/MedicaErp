using MedicaERPMVC.Application.ViewModels.Visits;

namespace MedicaERPMVC.Application.Services.Visit
{
    public interface IVisitService
    {
        int AddVisitAsync(NewVisitViewModel newVisitViewModel);
        void DeleteVisit(string id);
        Task<ListVisitsViewModel> GetAllVisitsForDoctor(string doCtorId, int pageSize, int pageNumber, string stringToFind, DateTime date);
        Task<IQueryable<VisitViewModel>> GetAllVisitsForList(int pageSize, int pageNumber, string stringToFind);
        Task<ListVisitsViewModel> GetNextVisitsForDoctorUpcoming(string doCtorId, int pageSize, int pageNumber, string stringToFind);
        Task<VisitViewModel> GetVisitId(string id);
        Task<bool> IsVisitPossible(string doctorId, DateTime date, TimeSpan timeStart);
    }
}