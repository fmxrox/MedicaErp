using MedicaERPMVC.Domain.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MedicaERPMVC.Domain.Model
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Sex Sex { get; set; }

        public string Adnotations { get; set; }

        public RoleOfUser RoleOfUser { get; set; }

        public bool isActivate { get; set; }
        public byte[] OwnPicture { get; set; }
        public int? SpecialitzationOfDoctorId { get; set; }

        public SpecialitzationOfDoctor? SpecialitzationOfDoctor { get; set; }
        public string? Pesel { get; set; }
        public virtual Clinic Clinic { get; set; }
        public UserContactInformation? UserContactInformation { get; set; }
        public virtual  ICollection<Visit> PatientVisits { get; set; }
    }
}