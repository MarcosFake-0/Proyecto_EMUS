using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Areas.Medicine.Controllers
{
    [Area("Medicine")]
    public class TreatmentController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public TreatmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Treatment> listtreatment = _unitOfWork.Treatment.GetAll().ToList();
            return View(listtreatment);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Treatment.Add(treatment);
                _unitOfWork.Save();

                return View();
            }
            TempData["success"] = "Tratamiento creado";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Edit(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Treatment.Update(treatment);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            TempData["success"] = "Tratamiento actualizado";
            return View();

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 && id == null)
            {
                return NotFound();
            }

            Treatment? TreatmentFromDb = _unitOfWork.Treatment.Get(x => x.Id == id);

            if (TreatmentFromDb == null)
            {
                return NotFound();
            }

            return View(TreatmentFromDb);

        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Treatment? TreatmentFromDb = _unitOfWork.Treatment.Get(x => x.Id == id);

            if (TreatmentFromDb == null)
            {
                return NotFound();
            }

            return View(TreatmentFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Treatment.Remove(treatment);
                _unitOfWork.Save();
                TempData["success"] = "Tratamiento eliminado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
