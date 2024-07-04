using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;
using Proyecto_EMUS.Models.ViewModels;
using Proyecto_EMUS.Utilities;

namespace Proyecto_EMUS.Areas.Medicine.Controllers
{
    [Area("Medicine")]
    [Authorize(Roles = ProyectoEMUSRoles.Role_Doctor + "," + ProyectoEMUSRoles.Role_Admin)]
    public class PatientController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult MedicalRecord(string? id)
        {
            if(id == null)
                return NotFound(); 

            Patient patient = _unitOfWork.Patient.Get(p => p.Id == id);

            if (patient == null)
                return NotFound();
            
            return View(patient);
        }

        [HttpGet]
        public IActionResult AddTreatmentToPatient(string? id)
        {
            if (id == null)
                return NotFound();

            PatientTreatmentVM patientTreatmentVM = new PatientTreatmentVM();

            patientTreatmentVM.Patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientTreatments.Treatment");

            if (patientTreatmentVM.Patient == null)
                return NotFound();


            patientTreatmentVM.Treatments = _unitOfWork.Treatment.GetAll().ToList(); 

            return View(patientTreatmentVM);
        }

        //Muestra dataTable con la lista de pacientes ordenados por fecha de atencion 
        #region API
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var listPatients = _unitOfWork.Patient.GetAll();

            if (listPatients == null)
                return Json(new { data = new List<Patient>() });

            return Json(new { listPatients });
        }
        #endregion
    }
}
