using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Areas.Admin.Controllers
{
    public class SpecialtyController : Controller
    {

        private IUnitOfWork _unitOfWork;

        public SpecialtyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
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
                return View();
            }
            TempData["success"] = "Especialidad Creada";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 && id == null)
            {
                return NotFound();
            }

            Specialty? specialtyFromDb = _unitOfWork.Specialty.Get(x => x.Id == id);

            if (specialtyFromDb == null)
            {
                return NotFound();
            }


            return View(specialtyFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Specialty.Update(specialty);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            TempData["success"] = "specialidad Actualizada";
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {

                return NotFound();
            }

            Specialty? specialtyFromdb = _unitOfWork.Specialty.Get(x => x.Id == id);

            if (specialtyFromdb == null)
            {
                return NotFound();
            }


            return View(specialtyFromdb);
        }

        [HttpPost]

        public IActionResult Delete(Specialty specialty)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Specialty.Remove(specialty);
                _unitOfWork.Save();
                RedirectToAction("Index");
                TempData["success"] = "especialidad Eliminada Correctamente";
            }
            return View();
        }


    }
}
