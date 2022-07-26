﻿using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Interface
{
    public interface IPatientRepository
    {
        IQueryable<User> GetAllPatients();
        User GetPatient(int id);
        int AddPatient(User patient);
        void UpdatePatient(User patient);
        void DeletePatient(int patientId);
    }
}
