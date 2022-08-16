
using MedicaERPMVC.Domain.Model.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model
{
    public class Clinic : IDetailsInfoModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public List<UserOfClinic> Employees { get; set; } = new List<UserOfClinic>();
        public DateTime DateOfCreation { get; set; }
        public DateTime? DateOfModification { get ; set; }
    }
}
