using MedicaERPMVC.Domain.Model.Const;
using MedicaERPMVC.Domain.Model.Enums;
using MedicaERPMVC.Domain.Model.Info;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model
{
    using static DataConstProperty;
    public class Doctor : IDetailsInfoModel
    {
        public int Id { get; set; }
        [Required]
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
        public int SpecializationId { get; set; }
        //public SpecialitzationOfDoctor SpecialitzationOfDoctor { get; set; }
        //public UserContactInformation? UserContactInformation { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime? DateOfModification { get; set; }
        public virtual ICollection<Visit> DoctorVisits { get; set; }
    }
}

