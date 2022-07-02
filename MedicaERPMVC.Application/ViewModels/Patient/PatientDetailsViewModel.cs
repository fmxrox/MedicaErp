﻿using MedicaERPMVC.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class PatientDetailsViewModel
    {   //last visits
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Domain.Model.Enums.Sex Sex { get; set; }
        public string Adnotations { get; set; }
        public List<UserContactInformationForViewModel> UserContactInformation { get; set; }
    }

}