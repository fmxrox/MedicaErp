using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicaERPMVC.Domain.Model.Info
{
    public interface IDetailsInfoModel
    {
        DateTime DateOfCreation { get; set; }

        DateTime? DateOfModification { get; set; }
    }
}
