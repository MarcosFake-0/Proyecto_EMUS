using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;
using Proyecto_EMUS.Utilities;

namespace Proyecto_EMUS.Areas.Medicine.Controllers
{
    [Area("Medicine")]
    [Authorize(Roles = ProyectoEMUSRoles.Role_Doctor + "," + ProyectoEMUSRoles.Role_Admin)]


    public class ConditionsController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ConditionsController(IUnitOfWork unitOfWork)
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
            Conditions conditions = new Conditions();
            if (id == null || id <= 0)
                return View(conditions);

            conditions = _unitOfWork.Conditions.Get(x => x.Id == id);
            return View(conditions);

        }

        [HttpPost]
        public IActionResult Upsert(Conditions conditions)
        {
            if (ModelState.IsValid)
            {
                if (conditions.Id == 0)
                    _unitOfWork.Conditions.Add(conditions);
                else
                    _unitOfWork.Conditions.Update(conditions);

                _unitOfWork.Save();
                TempData["success"] = "Condición guardada correctamente";
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
            var conditionsList = _unitOfWork.Conditions.GetAll();
            return Json(new { data = conditionsList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var conditionToDelete = _unitOfWork.Conditions.Get(x => x.Id == id);

            if (conditionToDelete == null)
                return Json(new { success = false, message = "Error al eliminar" });

            _unitOfWork.Conditions.Remove(conditionToDelete);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Condición eliminada exitosamente" });

        }

        #endregion


    }
}
