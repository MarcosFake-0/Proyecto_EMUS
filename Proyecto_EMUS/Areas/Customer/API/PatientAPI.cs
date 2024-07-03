using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;

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
        public IActionResult GetAllConditions(string? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientConditions.Conditions");
            var conditions = patient.PatientConditions.Select(x => x.Conditions);
            return Json(new { data = conditions }) ;
        }

        [HttpGet]
        public IActionResult GetAllTreatments(string? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientTreatments.Treatments");
            var treatments = patient.PatientTreatments.Select(x => x.Treatment);
            return Json(new { data = treatments });
        }

        [HttpGet]
        public IActionResult GetAllMedications(string? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientMedication.Medication");
            var medications = patient.PatientMedication.Select(x => x.Medication);
            return Json(new { data = medications });
        }

        [HttpGet]
        public IActionResult GetAllLaboratoryExam(string? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientLaboratoryExams.LaboratoryExam");
            var exams = patient.PatientLaboratoryExams.Select(x => new
            {
                LaboratoryExam = x.LaboratoryExam,
                FileUrl = x.FileUrl,
                ExamDate = x.ExamDate
            });
            return Json(new { data = exams });
        }

        [HttpGet]
        public IActionResult GetClinicalHistory(string? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "ClinicalHistoryNotes");
            var clinicalHistory = patient.ClinicalHistoryNotes.Select(note => new
            {
                note.Id,
                note.Description,
                note.DateTime
            });

            return Json(new { data = clinicalHistory });
        }
    }
}
