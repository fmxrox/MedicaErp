using MedicaERPMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain
{
    public class UserContactInformation
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Adress { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
