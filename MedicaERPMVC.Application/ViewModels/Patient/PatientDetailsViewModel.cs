using MedicaERPMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class PatientDetailsViewModel
    {   //last visits
        //history
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Pesel { get; set; }
        public Domain.Model.Enums.Sex Sex { get; set; }
        public string? Adnotations { get; set; }
        public UserContactInformationForViewModel? UserContactInformation { get; set; }
    }

}