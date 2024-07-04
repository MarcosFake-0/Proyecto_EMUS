using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Areas.Medicine.Controllers
{
    [Area("Medicine")]
    public class MedicationController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public MedicationController(IUnitOfWork unitOfWork)
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
            Medication medication = new Medication();
            if (id == null || id <= 0)
                return View(medication);

            medication = _unitOfWork.Medication.Get(x => x.Id == id);
            return View(medication);

        }

        [HttpPost]
        public IActionResult Upsert(Medication medication)
        {
            if (ModelState.IsValid)
            {
                if (medication.Id == 0)
                    _unitOfWork.Medication.Add(medication);
                else
                    _unitOfWork.Medication.Update(medication);

                _unitOfWork.Save();
                TempData["success"] = "Medicamento guardado correctamente";
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
            var medicationtList = _unitOfWork.Medication.GetAll();
            return Json(new { data = medicationtList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var medicationToDelete = _unitOfWork.Medication.Get(x => x.Id == id);

            if (medicationToDelete == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Medication.Remove(medicationToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Medicamento eliminado exitosamente" });

        }

        #endregion
    }
}
