using Microsoft.AspNetCore.Mvc;

namespace Proyecto_EMUS.Controllers
{
    public class HomeController : Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }

     
    }
}
