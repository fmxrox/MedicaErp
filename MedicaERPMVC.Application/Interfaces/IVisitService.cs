﻿using MedicaERPMVC.Application.ViewModels.Visits;

namespace MedicaERPMVC.Application.Services.Visit
{
    public interface IVisitService
    {
        int AddVisitAsync(NewVisitViewModel newVisitViewModel);
        void DeleteVisit(int id);
        Task<ListVisitsViewModel> GetAllVisitsForDoctor(string doCtorId, int pageSize, int pageNumber, string stringToFind, DateTime date);
        Task<ListVisitsViewModel> GetAllVisitsForDoctorToday(string doCtorId, int pageSize, int pageNumber, string? stringToFind, DateTime date);
        Task<ListVisitsViewModel> GetAllVisitsForList(int pageSize, int pageNumber, string stringToFind);
        Task<ListVisitsViewModel> GetNextVisitsForDoctorUpcoming(string doCtorId, int pageSize, int pageNumber, string stringToFind);
        Task<NewVisitViewModel> GetVisitId(int id);
        Task<bool> IsVisitPossible(string doctorId, DateTime date, TimeSpan timeStart);
       void UpdateVisit(NewVisitViewModel newVisitViewModel);
    }
}