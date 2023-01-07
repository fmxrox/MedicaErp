﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicaERP.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<UserOfClinic> _userManager;
        private readonly SignInManager<UserOfClinic> _signInManager;

        public IndexModel(
            UserManager<UserOfClinic> userManager,
            SignInManager<UserOfClinic> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]

            public string LastName { get; set; }
            public string? Adnotations { get; set; }
            public bool? isDoctor { get; set; }
            public bool? isEmployee { get; set; }
            public string? Pesel { get; set; }
            //public UserContactInformation? UserContactInformation { get; set; }

        }

        private async Task LoadAsync(UserOfClinic user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName= user.FirstName,
                LastName= user.LastName,
                Adnotations= user.Adnotations,
                isDoctor=user.isDoctor,
                isEmployee=user.isEmployee,
                Pesel=user.Pesel
                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            if (Input.FirstName != user.FirstName)
            {
                user.FirstName = Input.FirstName;
            }

            if (Input.LastName != user.LastName)
            {
                user.LastName = Input.LastName;
            }
            if (Input.isEmployee != user.isEmployee)
            {
                user.isEmployee = Input.isEmployee;
            }

            if (Input.isDoctor != user.isDoctor)
            {
                user.isDoctor = Input.isDoctor;
            }
            if (Input.Adnotations != user.Adnotations)
            {
                user.Adnotations = Input.Adnotations;
            }
            if (Input.Pesel != user.Pesel)
            {
                user.Pesel = Input.Pesel;
            }

            await _userManager.UpdateAsync(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
