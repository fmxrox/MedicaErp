using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedicaERPMVC.Application.ViewModels.Visits;
using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Model;
using System.Linq;
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
            var id = _visitRepository.AddVisit(visit);
            return id;

        }

        public void DeleteVisit(int id)
        {
            _visitRepository.DeleteVisit(id);
        }

        public async Task<IQueryable<VisitViewModel>> GetAllVisitsForList(int pageSize, int pageNumber, string stringToFind)
        {
            var visitsFromRepository = await _visitRepository.GetAllVisits();
            var visits = visitsFromRepository.ProjectTo<VisitViewModel>(_mapper.ConfigurationProvider).ToList();
            var visitFinally = visits.Skip(pageNumber).Take(pageSize).ToList();
            var visitsForListVM = new ListVisitsViewModel()
            {
                Visits = visits,
                Count = visits.Count(),
                PageSize = pageSize,
                ActualPage = pageNumber
            };
            return (IQueryable<VisitViewModel>)visitsForListVM;

        }
        public async Task<ListVisitsViewModel> GetAllVisitsForDoctor(string doCtorId, int pageSize, int pageNumber, string stringToFind)
        {
            var visitsFromRepository = await _visitRepository.GetVisitsToDo(doCtorId);
            var visits = visitsFromRepository.ProjectTo<VisitViewModel>(_mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Date).ToList();
            var visitFinally = visits.Skip(pageNumber).Take(pageSize).ToList();
            var visitsForListVM = new ListVisitsViewModel()
            {
                Visits = visits,
                Count = visits.Count(),
                PageSize = pageSize,
                ActualPage = pageNumber
            };
            return visitsForListVM;

        }

        public async Task<ListVisitsViewModel> GetNextVisitsForDoctorUpcoming(string doCtorId, int pageSize, int pageNumber, string stringToFind)
        {
            var visitsFromRepository = await _visitRepository.GetVisitsToDo(doCtorId);
            var visits = visitsFromRepository.Where(x => x.DoctorId == doCtorId
            && x.Date.Date < DateTime.UtcNow.Date
            && x.IsDone == false)
                .ProjectTo<VisitViewModel>(_mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Date).ToList();
            var visitFinally = visits.Skip(pageNumber).Take(pageSize).ToList();
            var visitsForListVM = new ListVisitsViewModel()
            {
                Visits = visits,
                Count = visits.Count(),
                PageSize = pageSize,
                ActualPage = pageNumber
            };
            return visitsForListVM;
        }

    }
}

