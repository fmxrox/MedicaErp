using MedicaERPMVC.Application.ViewModels.Visits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Application.ViewModels.Doctor
{
    public class DailySchemeDoctorViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public IEnumerable<VisitViewModel> Visits { get; set; }
    }
}
