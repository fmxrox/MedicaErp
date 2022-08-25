using AutoMapper;
using MedicaERPMVC.Application.ViewModels.Visits;
using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Model;
namespace MedicaERPMVC.Application.Services.Visit
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IMapper _mapper;
        public VisitService(IVisitRepository visitRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public int AddVisitAsync(NewVisitViewModel newVisitViewModel)
        {
            var visit = _mapper.Map<Domain.Model.Visit>(newVisitViewModel);
            var id=_visitRepository.AddVisit(visit);
            return id;

        }   

        public void DeleteVisit(int id)
        {
            _visitRepository.DeleteVisit(id);
        }

        public ListVisitsViewModel GetAllVisitsForList()
        {
            throw new NotImplementedException();
        }



        public Task<T> GetByIdAsync<T>(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetPastByUserAsync<T>(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetUpcomingByUserAsync<T>(string userId)
        {
            throw new NotImplementedException();
        }

        public Task RateAppointmentAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<T>> GetAllBySalonAsync<T>(string salonId)
        {
            throw new NotImplementedException();
        }
    }
}
