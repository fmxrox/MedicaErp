using Microsoft.AspNetCore.Mvc;

namespace MedicaERP.Web.Controllers.Visit
{
    public class VisitBase : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
