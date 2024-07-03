﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Areas.Admin.Controllers
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
            return View();
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Specialty specialty)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Specialty.Add(specialty);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Especialidad agregada correctamente";
        //    }

        //    return RedirectToAction("Index");

        //}

        //[HttpGet]
        //public IActionResult Edit(int? id)
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

        //[HttpPost]
        //public IActionResult Edit(Specialty specialty)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Specialty.Update(specialty);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Especialidad actualizada correctamente";
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}


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
