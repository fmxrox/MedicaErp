using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model
{ 
    public class SpecialitzationOfDoctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Doctors { get; set; } = new List<User>();

    }
}
