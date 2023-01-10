using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model
{
    public class Visit
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required]
        public string? PatientId { get; set; }
        public  UserOfClinic Patient { get; set; }
        [Required]
        public string? DoctorId { get; set; }
        public virtual UserOfClinic Doctor { get; set; }
        //public int? ClinicId { get; set; }
        //public virtual Clinic Clinic { get; set; }

        public int? VisitTypeId { get; set; }
        public virtual VisitType VisitType { get; set; }
        public bool? Confirmed { get; set; }
        public bool? IsDone { get; set; }

    }
}
