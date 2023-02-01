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

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]      
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }
        [Required]
        public string? PatientId { get; set; }
        public UserOfClinic Patient { get; set; }
        [Required]
        public string DoctorId { get; set; }
        public UserOfClinic Doctor
        {
            get; set;
        }
        public IEnumerable<SelectListItem> Doctors { get; set; }
        public int? ClinicId { get; set; }
        public Clinic Clinic { get; set; }


        [Display(Name ="Wykonano wizytę?")]
        public bool? IsDone { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Visit, VisitViewModel>();
               
        }
    }
}
