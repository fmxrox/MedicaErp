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
    public class NewVisitViewModel : IMapFrom<Visit>

    {
        public int Id { get; set; }
       public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required]
        public string PatientId { get; set; }
        public UserOfClinic Patient { get; set; }
        [Required]
        public int? ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
        public int VisitTypeId { get; set; }
        public virtual VisitType VisitType { get; set; }
        public bool Confirmed { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string DoctorId { get; set; }
        public IEnumerable<SelectListItem> Doctors { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewVisitViewModel, Visit>();
        }
    }

    
}
