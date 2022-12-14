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
    public class DoctorDetailsViewModel : IMapFrom<Domain.Model.UserOfClinic>
    {   //last visits
        //history
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? Adnotations { get; set; }
        //public UserContactInformationForViewModel? UserContactInformation { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.UserOfClinic, DoctorDetailsViewModel>()
                .ForMember(d => d.Id, p => p.MapFrom(s => s.Id))
                .ForMember(d => d.FullName, p => p.MapFrom(s => s.FirstName + " " + s.LastName));     
        }
    }

}