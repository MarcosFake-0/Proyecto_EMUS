using Microsoft.AspNetCore.Mvc;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

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
            var conditions = patient.PatientConditions.Select(x => x.Conditions);
            return Json(new { data = conditions }) ;
        }

        [HttpGet]
        public IActionResult GetAllTreatments(int? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientTreatments.Treatments");
            var treatments = patient.PatientTreatments.Select(x => x.Treatment);
            return Json(new { data = treatments });
        }

        [HttpGet]
        public IActionResult GetAllMedications(int? id)
        {
            var patient = _unitOfWork.Patient.Get(x => x.Id == id, includeProperties: "PatientMedication.Medication");
            var medications = patient.PatientMedication.Select(x => x.Medication);
            return Json(new { data = medications });
        }

        [HttpGet]
        public IActionResult GetAllLaboratoryExam(int? id)
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
        public IActionResult GetClinicalHistory(int? id)
        {
            var clinicalHistory = _unitOfWork.ClinicalHistory.Get(x => x.PatientId == id, includeProperties:"ClinicalHistoryNotes");
            var clinicalHistoryNotes = clinicalHistory.ClinicalHistoryNotes.Select(x => x.Id);
            return Json(new { data = clinicalHistoryNotes });
        }
    }
}
