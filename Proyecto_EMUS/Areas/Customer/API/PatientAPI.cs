using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Areas.Customer.API
{
    [Area("Customer")]
    public class PatientAPI : Controller
    {
        private IUnitOfWork _unitOfWork;

        public PatientAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllConditions(int? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientConditions.Conditions");
            var conditions = patient.PatientConditions.Select(x => x.Conditions).ToList();
            return Json(conditions);
        }

    }
}
