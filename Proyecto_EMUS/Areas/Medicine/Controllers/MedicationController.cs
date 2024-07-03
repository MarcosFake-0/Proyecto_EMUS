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
            List<Medication> listMedications = _unitOfWork.Medication.GetAll().ToList();
            return View(listMedications);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medication medication)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Medication.Add(medication);
                _unitOfWork.Save();

                return View();
            }
            TempData["success"] = "Medicamento creado";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Edit(Medication medication)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Medication.Update(medication);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            TempData["success"] = "Medicamento actualizado";
            return View();

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 && id == null)
            {
                return NotFound();
            }

            Medication? medicationFromDb = _unitOfWork.Medication.Get(x => x.Id == id);

            if (medicationFromDb == null)
            {
                return NotFound();
            }

            return View(medicationFromDb);

        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medication? medicationFromDb = _unitOfWork.Medication.Get(x => x.Id == id);

            if (medicationFromDb == null)
            {
                return NotFound();
            }

            return View(medicationFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Medication medication)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Medication.Remove(medication);
                _unitOfWork.Save();
                TempData["success"] = "Medicamento eliminado correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
