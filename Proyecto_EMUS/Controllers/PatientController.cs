using Microsoft.AspNetCore.Mvc;

namespace Proyecto_EMUS.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
