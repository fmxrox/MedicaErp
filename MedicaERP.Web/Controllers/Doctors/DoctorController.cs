using Microsoft.AspNetCore.Mvc;

namespace MedicaERP.Web.Controllers.Doctors
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
