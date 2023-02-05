using AutoMapper;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Domain.Model;


namespace MedicaERPMVC.Application.ViewModels.Visits
{
    public class ListVisitsViewModel : IMapFrom<Visit>
    {
        public List<VisitViewModel> Visits { get; set; }
        public int Count { get; set; }
        public int ActualPage { get; set; }
        public int PageSize { get; set; }
        public string StringToSearch { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Visit, VisitViewModel>();
         
        }
    }
}
