using AutoMapper;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Visits
{
    public class VisitViewModel : IMapFrom<Visit>
    {
        public string Id { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required]
        public string PatientId { get; set; }
        public UserOfClinic Patient { get; set; }
        [Required]
        public string DoctorId { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public int VisitTypeId { get; set; }
        public VisitType VisitType { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Visit, VisitViewModel>()
                .ForMember(d => d.Id, p => p.MapFrom(s => s.Id))
                .ForMember(d => d.Description, p => p.MapFrom(s => s.Description))
                .ForMember(d => d.Patient, p => p.MapFrom(s => s.Patient))
                .ForMember(d => d.DoctorId, p => p.MapFrom(d => d.Doctor))
                .ForMember(d => d.Clinic, p => p.MapFrom(s => s.Clinic))
                .ForMember(d => d.VisitType, p => p.MapFrom(s => s.VisitType));
        }
    }
}
