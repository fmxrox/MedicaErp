using MedicaERPMVC.Domain.Model.Const;
using MedicaERPMVC.Domain.Model.Enums;
using MedicaERPMVC.Domain.Model.Info;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MedicaERPMVC.Domain.Model
{
    using static DataConstProperty;
    //USEROFCLINIC MOZE ZROBIER TYLKO PACJENTA I TYLE 
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
        public bool IsPatient { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adnotations { get; set; }
        public bool isDoctor { get; set; }
        public RoleOfUser RoleOfUser { get; set; }
        public bool isActivate { get; set; }
        public byte[]? OwnPicture { get; set; }
        public string Pesel { get; set; }
        //public UserContactInformation? UserContactInformation { get; set; }
        public IQueryable<Visit> PatientVisits { get; set; }
        public IQueryable<Visit> DoctorVisits { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime? DateOfModification { get; set; }
    }
}