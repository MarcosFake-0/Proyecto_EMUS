using Microsoft.AspNetCore.Mvc;

namespace Proyecto_EMUS.Areas.Medicine.Controllers
{
    public class MedicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
