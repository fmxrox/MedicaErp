using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model
{
    public class Clinic
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Adress { get; set; }
        public string? Description { get; set; }
        public List<User> Employees { get; set; } = new List<User>();
     
    }
}
