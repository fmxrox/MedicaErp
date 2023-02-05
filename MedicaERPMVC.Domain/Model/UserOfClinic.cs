using MedicaERPMVC.Domain.Model.Const;
using MedicaERPMVC.Domain.Model.Enums;
using MedicaERPMVC.Domain.Model.Info;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MedicaERPMVC.Domain.Model
{
    using static DataConstProperty;
    public class UserOfClinic : IdentityUser
    {
        [Required]
        [MinLength(MinRequiredName)]
        [MaxLength(MaxRequiredName)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(MinRequiredName)]
        [MaxLength(MaxRequiredName)]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adnotations { get; set; }
        public bool? isDoctor { get; set; }
         public bool? isEmployee { get; set; }
        public string? Pesel { get; set; }
        public int? ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
        public ICollection<Visit> PatientVisits { get; set; }
        public ICollection<Visit> DoctorVisits { get; set; }
 
    }
}