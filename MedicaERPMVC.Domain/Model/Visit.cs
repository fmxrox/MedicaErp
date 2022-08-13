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

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        [Required]
        public string PatientId { get; set; }
        public  Patient Patient { get; set; }
        [Required]
        public string DoctorId { get; set; }
        public  Patient Doctor { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public int VisitTypeId { get; set; }
        public  VisitType VisitType { get; set; }
        public bool? Confirmed { get; set; }
        public bool? IsDone { get; set; }

    }
}
