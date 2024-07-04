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
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Treatment treatment = new Treatment();
            if (id == null || id <= 0)
                return View(treatment);

            treatment = _unitOfWork.Treatment.Get(x => x.Id == id);
            return View(treatment);

        }

        [HttpPost]
        public IActionResult Upsert(Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                if (treatment.Id == 0)
                    _unitOfWork.Treatment.Add(treatment);
                else
                    _unitOfWork.Treatment.Update(treatment);

                _unitOfWork.Save();
                TempData["success"] = "Tratamiento guardado correctamente";
            }
            else
            {
                TempData["error"] = "Error al guardar";
            }
            return RedirectToAction("Index");
        }

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var treatmentList = _unitOfWork.Treatment.GetAll();
            return Json(new { data = treatmentList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var treatmentToDelete = _unitOfWork.Treatment.Get(x => x.Id == id);

            if (treatmentToDelete == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Treatment.Remove(treatmentToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Tratamiento eliminado exitosamente" });

        }

        #endregion


    }
}
