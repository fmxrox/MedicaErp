using MedicaERPMVC.Domain.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MedicaERPMVC.Domain.Model
{
    public class User : IdentityUser
    { 
       
        [MaxLength(30)]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(35)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Sex Sex { get; set; }

        public string Adnotations { get; set; }

        public RoleOfUser RoleOfUser { get; set; }

        public int? SpecialitzationOfDoctorId { get; set; }

        public SpecialitzationOfDoctor? SpecialitzationOfDoctor { get; set; }

        //PatientID i DoctorID 
        public string? Pesel { get; set; }
        public int? ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }

        public UserContactInformation UserContactInformation { get; set; }

        public virtual ICollection<Visit> DoctorsVisits { get; set; }

        public virtual  ICollection<Visit> PatientVisits { get; set; }
    }
}