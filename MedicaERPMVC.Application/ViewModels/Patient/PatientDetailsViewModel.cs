using AutoMapper;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Domain;
using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class PatientDetailsViewModel : IMapFrom<Domain.Model.Patient>
    {   //last visits
        //history
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Pesel { get; set; }
        public Domain.Model.Enums.Sex Sex { get; set; }
        public string? Adnotations { get; set; }
        public UserContactInformationForViewModel? UserContactInformation { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Patient, PatientDetailsViewModel>()
                .ForMember(d => d.Id, p => p.MapFrom(s => s.Id))
                .ForMember(d => d.FullName, p=> p.MapFrom(s=> s.FirstName+" "+ s.LastName))
                .ForMember(d => d.DateOfBirth, p => p.MapFrom(d => d.DateOfBirth))
                .ForMember(d => d.Sex, p => p.MapFrom(s => s.Sex));
     
        }
    }

}