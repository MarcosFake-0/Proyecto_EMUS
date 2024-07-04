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
                if (_unitOfWork.Patient.Get(x => x.Id == patient.Id) == null)
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
        public IActionResult PatientTreatment (string? id)
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

        [HttpPost]
        public IActionResult PatientTreatment(PatientTreatmentVM patientTreatmentVM)
        {
            if (ModelState.IsValid)
            {
                Treatment treatmentToAdd = _unitOfWork.Treatment.Get(x => x.Id == patientTreatmentVM.Treatment.Id);

                if (treatmentToAdd == null)
                    return NotFound();

                DateTime now = DateTime.UtcNow;
                PatientTreatment pt = new()
                {
                    IdPatient = patientTreatmentVM.Patient.Id,
                    IdTreatment = patientTreatmentVM.Treatment.Id,
                    CreatedByDoctorId = 309081,
                    CreatedAt = now
                };
                _unitOfWork.PatientTreatment.Add(pt);
                _unitOfWork.Save();
            }
            //return RedirectToAction("Index");
            return RedirectToAction("PatientTreatment", new { id = patientTreatmentVM.Patient.Id });
        }

        [HttpDelete]
        public IActionResult SuspendTreatment (string? idPatient, int? idTreatment)
        {
            if (idPatient == null || idTreatment <= 0 || idTreatment == null)
                return NotFound();

            Patient? patient = _unitOfWork.Patient.Get(x => x.Id.Equals(idPatient));
            Treatment? treatment = _unitOfWork.Treatment.Get(x => x.Id == idTreatment);

            if (patient == null | treatment == null)
                return NotFound();

            PatientTreatment pt = new()
            {
                IdPatient = patient.Id,
                IdTreatment = treatment.Id
            };

            _unitOfWork.PatientTreatment.Remove(pt);
            _unitOfWork.Save();

            return Ok();
            //return RedirectToAction("PatientTreatment", new { id = idPatient}); 
        }


        [HttpGet]
        public IActionResult PatientMedication(string? id)
        {
            if (id == null)
                return NotFound();

            PatientMedicationVM patientMedicationVM = new()
            {
                Patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientMedication.Medication")
            };

            if (patientMedicationVM.Patient == null)
                return NotFound();

            List<Medication> allMedication = _unitOfWork.Medication.GetAll().ToList();
            List<Medication> patientMedication = patientMedicationVM.Patient.PatientMedication.Select(pt => pt.Medication).ToList();
            List<Medication> medicationNoAssociated = allMedication.Except(patientMedication).ToList();

            patientMedicationVM.Medications = medicationNoAssociated.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            if (patientMedication == null)
                patientMedicationVM.PatientMedication = new List<Medication>();

            patientMedicationVM.PatientMedication = patientMedication;
            patientMedicationVM.Medication = new Medication();

            return View(patientMedicationVM);
        }

        [HttpPost]
        public IActionResult PatientMedication(PatientMedicationVM patientMedicationVM)
        {
            if (ModelState.IsValid)
            {
                Medication medicationToAdd = _unitOfWork.Medication.Get(x => x.Id == patientMedicationVM.Medication.Id);

                if (medicationToAdd == null)
                    return NotFound();

                DateTime now = DateTime.UtcNow;
                PatientMedication pm = new()
                {
                    IdPatient = patientMedicationVM.Patient.Id,
                    IdMedication = patientMedicationVM.Medication.Id,
                    CreatedByDoctorId = 309081,
                    CreatedAt = now
                };
                _unitOfWork.PatientMedication.Add(pm);
                _unitOfWork.Save();
            }
            //return RedirectToAction("Index");
            return RedirectToAction("PatientMedication", new { id = patientMedicationVM.Patient.Id });
        }

        [HttpDelete]
        public IActionResult SuspendMedication(string? idPatient, int? idMedication)
        {
            if (idPatient == null || idMedication <= 0 || idMedication == null)
                return NotFound();

            Patient? patient = _unitOfWork.Patient.Get(x => x.Id.Equals(idPatient));
            Medication? treatment = _unitOfWork.Medication.Get(x => x.Id == idMedication);

            if (patient == null | treatment == null)
                return NotFound();

            PatientMedication pm = new()
            {
                IdPatient = patient.Id,
                IdMedication = treatment.Id
            };

            _unitOfWork.PatientMedication.Remove(pm);
            _unitOfWork.Save();

            return Ok();
            //return RedirectToAction("PatientTreatment", new { id = idPatient}); 
        }

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
            //return View(patientMedicationVM);
        }
        #endregion
    }
}

