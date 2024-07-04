using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(string? id)
        {
            Patient patient = new Patient();
            if (id == null)
                return View(patient);

            patient = _unitOfWork.Patient.Get(x => x.Id == id);
            return View(patient);

        }

        [HttpPost]
        public IActionResult Upsert(Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patient.Id == null)
                    _unitOfWork.Patient.Add(patient);
                else
                    _unitOfWork.Patient.Update(patient);

                _unitOfWork.Save();
                TempData["success"] = "Paciente guardado correctamente";
            }
            else
            {
                TempData["error"] = "Error al guardar";
            }
            return RedirectToAction("Index");
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

            PatientTreatmentVM patientTreatmentVM = new()
            {
                Patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientTreatments.Treatment")
            };

            if (patientTreatmentVM.Patient == null)
              return NotFound();

            List<Treatment> allTreatments = _unitOfWork.Treatment.GetAll().ToList();
            List<Treatment> patientTreatments = patientTreatmentVM.Patient.PatientTreatments.Select(pt => pt.Treatment).ToList();
            List<Treatment> treatmentsNoAssociated = allTreatments.Except(patientTreatments).ToList();

            patientTreatmentVM.Treatments = treatmentsNoAssociated.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            if (patientTreatments == null)
                patientTreatmentVM.PatientTreatments = new List<Treatment>();

            patientTreatmentVM.PatientTreatments = patientTreatments;
            patientTreatmentVM.Treatment = new Treatment();

            return View(patientTreatmentVM);
        }

        //[HttpPost]
        //public IActionResult AddTreatmentToPatient(PatientTreatmentVM patientTreatmentVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Treatment treatmentToAdd = _unitOfWork.Treatment.Get(x => x.Id == patientTreatmentVM.Treatment.Id);

        //        if (treatmentToAdd == null)
        //            return NotFound();

        //        PatientTreatment pt = new PatientTreatment();
        //        pt.IdPatient = patientTreatmentVM.Patient.Id;
        //        pt.IdTreatment = treatmentToAdd.Id;
        //        _unitOfWork.PatientTreatment.Add(pt);
        //    }
        //    return View(patientTreatmentVM.Patient.Id);
        //}

        #region API
        //Muestra dataTable con la lista de pacientes ordenados por fecha de atencion
        [HttpGet]
        public IActionResult GetAllPatients()
        {
            var patientList = _unitOfWork.Patient.GetAll();
            return Json(new { data = patientList });
        }

        //PRUEBA
        [HttpGet]
        public IActionResult AddTreatmentToPatientAPI(string? id)
        {
            if (id == null)
                return Json(new {data = new List<Treatment>()});
                //return NotFound();

            PatientTreatmentVM patientTreatmentVM = new()
            {
                Patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientTreatments.Treatment")
            };

            if (patientTreatmentVM.Patient == null)
                return Json(new { data = new Patient()});
            //return NotFound();

            List<Treatment> allTreatments = _unitOfWork.Treatment.GetAll().ToList();
            List<Treatment> patientTreatments = patientTreatmentVM.Patient.PatientTreatments.Select(pt => pt.Treatment).ToList();
            List<Treatment> treatmentsNoAssociated = allTreatments.Except(patientTreatments).ToList();

            patientTreatmentVM.Treatments = treatmentsNoAssociated.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            if (patientTreatments == null)
                patientTreatmentVM.PatientTreatments = new List <Treatment>();

            patientTreatmentVM.PatientTreatments = patientTreatments;
            patientTreatmentVM.Treatment = new Treatment();

            return Json(new {data = patientTreatmentVM.Patient});
            //return View(patientTreatmentVM);
        }
        #endregion
    }
}
