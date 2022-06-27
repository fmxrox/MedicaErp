using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model
{
    public class VisitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
