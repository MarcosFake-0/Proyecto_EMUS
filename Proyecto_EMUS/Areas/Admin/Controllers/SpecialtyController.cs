using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;
using Proyecto_EMUS.Utilities;

namespace Proyecto_EMUS.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = ProyectoEMUSRoles.Role_Admin)]
    public class SpecialtyController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public SpecialtyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Specialty specialty = new Specialty();
            if (id == null || id <= 0)
                return View(specialty);

            specialty = _unitOfWork.Specialty.Get(x => x.Id == id);
            return View(specialty);

        }

        [HttpPost]
        public IActionResult Upsert(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                if (specialty.Id == 0)
                    _unitOfWork.Specialty.Add(specialty);
                else
                    _unitOfWork.Specialty.Update(specialty);

                _unitOfWork.Save();
                TempData["success"] = "Especialidad guardada correctamente";
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
            var specialtyList = _unitOfWork.Specialty.GetAll();
            return Json(new { data = specialtyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var specialtyToDelete = _unitOfWork.Specialty.Get(x => x.Id == id);

            if (specialtyToDelete == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Specialty.Remove(specialtyToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Especialidad eliminada exitosamente" });

        }

        #endregion
    }
}
