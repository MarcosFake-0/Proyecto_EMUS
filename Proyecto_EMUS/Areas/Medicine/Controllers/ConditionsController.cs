using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Areas.Medicine.Controllers
{
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
            List<Conditions> listcondition = _unitOfWork.Conditions.GetAll().ToList();
            return View(listcondition);
        }


        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        [HttpPost]

        public IActionResult Create(Conditions condition)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Conditions.Add(condition);
                _unitOfWork.Save(); 



                return View();
            }
            TempData["success"] = "Condicion Creada";
            return RedirectToAction("Index");



        }



        [HttpPost]
        public IActionResult Edit(Conditions condition)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Conditions.Update(condition);
                _unitOfWork.Save();



                return RedirectToAction("Index");
            }
            TempData["success"] = "Condicion Actualizada";
            return View();

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 && id == null)
            {
                return NotFound();
            }

            Conditions? ConditionFromDb = _unitOfWork.Conditions.Get(x => x.Id == id);

            if (ConditionFromDb == null)
            {
                return NotFound();
            }

            return View(ConditionFromDb);

        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conditions? ConditionFromDb = _unitOfWork.Conditions.Get(x => x.Id == id);

            if (ConditionFromDb == null)
            {
                return NotFound();
            }

            return View(ConditionFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Conditions condition)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Conditions.Remove(condition);
                _unitOfWork.Save();
                TempData["success"] = "Condicion Eliminada Correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
