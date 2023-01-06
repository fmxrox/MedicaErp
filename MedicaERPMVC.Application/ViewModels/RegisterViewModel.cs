using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adnotations { get; set; }
        [Display(Name = "Zarejestrować jako lekarz")]
        public bool IsDoctor { get; set; }
        public bool? isEmployee { get; set; }
        public string Pesel { get; set; }
        //public UserContactInformation? UserContactInformation { get; set; }
        public int ClinicId { get; set; }
        public IEnumerable<SelectListItem> Clinics { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Hasło {0} musi mieć co najmniej {2} i maksymalnie {1} znaków", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Potwierdzone hasło nie pasuje")]
        public string ConfirmPassword { get; set; }
    }
}
