using MedicaERPMVC.Domain.Model.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using MedicaERPMVC.Domain.Model.Const;
using MedicaERPMVC.Domain.Model.Info;

namespace MedicaERPMVC.Domain.Model
{
    using static DataConstProperty;
    public class User : IdentityUser, IDetailsInfoModel
    {   [Required]
        [MinLength(MinRequiredName)]
        [MaxLength(MaxRequiredName)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(MinRequiredName)]
        [MaxLength(MaxRequiredName)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adnotations { get; set; }
        public bool isMedic { get; set; }
        public RoleOfUser RoleOfUser { get; set; }
        public bool isActivate { get; set; }
        public byte[]? OwnPicture { get; set; }
        public string Pesel { get; set; }
        public int SpecializationId { get; set; }
        public SpecialitzationOfDoctor SpecialitzationOfDoctor { get; set; }
        public int ClinicId { get; set; }
        public  Clinic Clinic { get; set; }
        //public UserContactInformation? UserContactInformation { get; set; }
        public IQueryable<Visit> PatientVisits { get; set; }
        public IQueryable<Visit> DoctorVisits { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime? DateOfModification { get; set; }
    }
}