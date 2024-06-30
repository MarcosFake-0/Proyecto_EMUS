using Microsoft.AspNetCore.Mvc;

namespace Proyecto_EMUS.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
