using AutoMapper;
using FluentValidation;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class NewDoctorViewModel : IMapFrom<Domain.Model.UserOfClinic>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Pesel { get; set; }

        public bool isDoctor { get; set; }
        public IQueryable<Visit> PatientVisits { get; set; }
        public IQueryable<Visit> DoctorVisits { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewDoctorViewModel, Domain.Model.UserOfClinic>().ReverseMap();      
        }

        public class NewCustomerValidation : AbstractValidator<NewDoctorViewModel>
        {
            public NewCustomerValidation()
            {            
                RuleFor(x => x.Pesel).Length(11);
                //RuleFor(x => x.Mail).EmailAddress();
            }
        }
    }
}
