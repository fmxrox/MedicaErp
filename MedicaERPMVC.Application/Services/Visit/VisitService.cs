﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedicaERPMVC.Application.ViewModels.Visits;
using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Model;
using System.Linq;
namespace MedicaERPMVC.Application.Services.Visit
{
    public class VisitService : IVisitService
    {
        //DOPISAC CZY WIZYTA JEST MOZLIWA
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
            visit.IsDone = false;
            visit.Confirmed = false;
            var id = _visitRepository.AddVisit(visit);
            return id;


        }
        public async Task<NewVisitViewModel> GetVisitId(int id)

        {
            var visit = await _visitRepository.GetVisitById(id);
            var visitVm = _mapper.Map<NewVisitViewModel>(visit);
            return visitVm;
        }
        public void DeleteVisit(int id)
        {
            _visitRepository.DeleteVisit(id);
        }

        public async Task<ListVisitsViewModel> GetAllVisitsForList(int pageSize, int pageNumber, string stringToFind)
        {
            var visitsFromRepository =  _visitRepository.GetAllVisits();
            var visits = visitsFromRepository.ProjectTo<VisitViewModel>(_mapper.ConfigurationProvider).ToList();
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
        public async Task<ListVisitsViewModel> GetAllVisitsForDoctor(string doCtorId, int pageSize, int pageNumber, string? stringToFind, DateTime date)
        {
            var visitsFromRepository = await _visitRepository.GetVisitsToDo(doCtorId);
            var visits = visitsFromRepository.ProjectTo<VisitViewModel>(_mapper.ConfigurationProvider)
                .Where(x => x.DoctorId == doCtorId)
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

        public async Task<ListVisitsViewModel> GetNextVisitsForDoctorUpcoming(string doCtorId, int pageSize, int pageNumber, string? stringToFind)
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
        public async Task<bool> IsVisitPossible(string doctorId, DateTime date, TimeSpan timeStart)
        {
            var result =  _visitRepository
            .GetAllVisits();
            var isPossibleToBook = result.Any((a => a
                 .DoctorId == doctorId
               && a.Date.Date == date.Date
              && a.StartTime == timeStart));
            return isPossibleToBook;

        }

        public void UpdateVisit(NewVisitViewModel newVisitViewModel)
        {
            var visit = _mapper.Map<MedicaERPMVC.Domain.Model.Visit>(newVisitViewModel);
            _visitRepository.VisitEditAsync(visit);
        }
    }
}