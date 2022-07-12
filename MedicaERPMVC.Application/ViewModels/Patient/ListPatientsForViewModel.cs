using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class ListPatientsForListViewModel
    {
        public List<PatientForListViewModel>? Patients { get; set; }
        public int Count { get; set; }
        public int ActualPage { get; set; }
        public int PageSize { get; set; }
        public string StringToSearch { get; set; }
    }
}
