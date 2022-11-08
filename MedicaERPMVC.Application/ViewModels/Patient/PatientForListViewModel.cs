using AutoMapper;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class PatientForListViewModel : IMapFrom<Domain.Model.UserOfClinic>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Pesel{ get; set; }
        public string? PhoneNumber{ get; set; }
        public DateTime DateOfBirth { get; set; }
        public Domain.Model.Enums.Sex Sex { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.UserOfClinic, PatientForListViewModel>()
                .ForMember(d => d.Id, p => p.MapFrom(s => s.Id))
                .ForMember(d => d.Name, p => p.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, p => p.MapFrom(s => s.LastName))
                .ForMember(d => d.DateOfBirth, p => p.MapFrom(d => d.DateOfBirth))
                .ForMember(d => d.Sex, p => p.MapFrom(s => s.Sex))
                .ForMember(d => d.PhoneNumber, p => p.MapFrom(s => s.PhoneNumber));
        }
    }
}
