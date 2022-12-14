﻿using AutoMapper;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class ListDoctorsForListViewModel : IMapFrom<Domain.Model.UserOfClinic>
    {
        public IQueryable<UserOfClinic> Doctors { get; set; }
        public int Count { get; set; }
        public int ActualPage { get; set; }
        public int PageSize { get; set; }
        public string StringToSearch { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.UserOfClinic, PatientForListViewModel>();
        }
    }
}