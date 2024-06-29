using Microsoft.AspNetCore.Mvc;

namespace Proyecto_EMUS.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
