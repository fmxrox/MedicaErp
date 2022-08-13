using AutoMapper;
using MedicaERPMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class ListPatientsForListViewModel : IMapFrom<Domain.Model.Patient>
    {
        public List<PatientForListViewModel> Patients { get; set; }
        public int Count { get; set; }
        public int ActualPage { get; set; }
        public int PageSize { get; set; }
        public string StringToSearch { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Patient, PatientForListViewModel>()
                .ForMember(d => d.Id, p => p.MapFrom(s => s.Id))
                .ForMember(d => d.Name, p => p.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, p => p.MapFrom(s => s.LastName))
                .ForMember(d => d.DateOfBirth, p => p.MapFrom(d => d.DateOfBirth))
                .ForMember(d => d.Sex, p => p.MapFrom(s => s.Sex))
                .ForMember(d => d.PhoneNumber, p => p.MapFrom(s => s.PhoneNumber));
        }
    }
}
