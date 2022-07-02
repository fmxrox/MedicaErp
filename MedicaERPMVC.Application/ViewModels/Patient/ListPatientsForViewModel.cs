using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class ListPatientsForViewModel
    {
        public List<PatientForListViewModel> Patients { get; set; }
        public int Count { get; set; }
    }
}
