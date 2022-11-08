using MedicaERPMVC.Domain.Model.Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model
{ 
    public class SpecialitzationOfDoctor : IDetailsInfoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserOfClinic> Doctors { get; set; } = new List<UserOfClinic>();
        public DateTime DateOfCreation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? DateOfModification { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
