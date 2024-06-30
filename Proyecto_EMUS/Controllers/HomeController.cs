using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;

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
