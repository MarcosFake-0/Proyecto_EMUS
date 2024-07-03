using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Areas.Admin.Controllerss
{
    [Area("Admin")]
    public class SpecialtyController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public SpecialtyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Specialty> specialtyList = _unitOfWork.Specialty.GetAll().ToList();
            return View(specialtyList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Specialty.Add(specialty);
                _unitOfWork.Save();
                TempData["success"] = "Especialidad agregada correctamente";
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Specialty? specialty = _unitOfWork.Specialty.Get(x => x.Id == id);

            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        [HttpPost]
        public IActionResult Edit(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Specialty.Update(specialty);
                _unitOfWork.Save();
                TempData["success"] = "Especialidad actualizada correctamente";
                return RedirectToAction("Index");
            }

            return View();
        }

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    Specialty? specialty = _unitOfWork.Specialty.Get(x => x.Id == id);

        //    if (specialty == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(specialty);
        //}



        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePOST(int? id)
        //{
        //    Specialty? specialty = _unitOfWork.Specialty.Get(x => x.Id == id);

        //    if (specialty == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Specialty.Remove(specialty);
        //    _unitOfWork.Save();

        //    TempData["success"] = "Especialidad eliminada correctamente";
        //    return RedirectToAction("Index");

        //}

        #region API
        [HttpGet]
        public IActionResult GetAll()
        {
            var specialtyList = _unitOfWork.Specialty.GetAll();
            return Json(new { data = specialtyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var specialtyToDelete = _unitOfWork.Specialty.Get(x => x.Id == id);

            if (specialtyToDelete == null)
                return Json(new { success = false, message = "Error while deleting" });

            _unitOfWork.Specialty.Remove(specialtyToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully" });

        }

        #endregion
    }
}
