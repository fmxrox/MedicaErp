using AutoMapper;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class DoctorForListVM : IMapFrom<UserOfClinic>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber{ get; set; }
        public bool isDoctor { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserOfClinic, DoctorForListVM>();
        }
    }
}
