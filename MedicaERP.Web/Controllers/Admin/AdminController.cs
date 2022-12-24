using Microsoft.AspNetCore.Mvc;

namespace MedicaERP.Web.Controllers.Admin
{
    public class AdminController : Controller
    {//dodawanie lekarzy i placowek medycznych 
        //
        public IActionResult Index()
        {
            return View();
        }
    }
}
