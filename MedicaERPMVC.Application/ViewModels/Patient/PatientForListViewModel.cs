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
    public class PatientForListViewModel : IMapFrom<UserOfClinic>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Pesel{ get; set; }
        public string? PhoneNumber{ get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MedicaERPMVC.Domain.Model.UserOfClinic, MedicaERPMVC.Application.ViewModels.Patient.PatientForListViewModel>() 
                .ForMember(d => d.Name, p => p.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, p => p.MapFrom(d => d.LastName))
                .ForMember(d => d.Pesel, p => p.MapFrom(s => s.Pesel))
                .ForMember(d => d.PhoneNumber, p => p.MapFrom(s => s.PhoneNumber));
        }
    }
}
