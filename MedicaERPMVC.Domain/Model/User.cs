using MedicaERPMVC.Domain.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MedicaERPMVC.Domain.Model
{
    public class User : IdentityUser
    {   [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adnotations { get; set; }
        public bool isPatient { get; set; }
        public RoleOfUser RoleOfUser { get; set; }
        public bool isActivate { get; set; }
        public byte[]? OwnPicture { get; set; }
        public string Pesel { get; set; }
        public int SpecializationId { get; set; }
        public SpecialitzationOfDoctor SpecialitzationOfDoctor { get; set; }
        public int ClinicId { get; set; }
        public  Clinic Clinic { get; set; }
        //public UserContactInformation? UserContactInformation { get; set; }
        public ICollection<Visit> PatientVisits { get; set; }
        public ICollection<Visit> DoctorVisits { get; set; } 
    }
}