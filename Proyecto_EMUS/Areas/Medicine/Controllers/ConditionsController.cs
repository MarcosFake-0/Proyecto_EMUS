using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;

namespace Proyecto_EMUS.Areas.Medicine.Controllers
{
    public class ConditionsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ConditionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
