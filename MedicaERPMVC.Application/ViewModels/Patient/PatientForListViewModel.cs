using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Patient
{
    public class PatientForListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pesel{ get; set; }
        public DateTime DateOfBirth { get; set; }
        public Domain.Model.Enums.Sex Sex { get; set; }

    }
}
