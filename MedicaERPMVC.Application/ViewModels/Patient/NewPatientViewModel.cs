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
    public class NewPatientViewModel : IMapFrom<Domain.Model.Patient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public string Sex { get; set; }
        public string Pesel { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewPatientViewModel, Domain.Model.Patient>();
                

        }
    }
}
