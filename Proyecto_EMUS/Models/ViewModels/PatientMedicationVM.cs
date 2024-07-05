using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_EMUS.Areas.Medicine.Controllers;

namespace Proyecto_EMUS.Models.ViewModels
{
    public class PatientMedicationVM
    {
        //Patient who will to add the medication
        [ValidateNever]
        public Patient Patient {  get; set; }

        //All tratments that patient doesn't has 
        [ValidateNever]
        public IEnumerable<SelectListItem> Medications { get; set; }

        //All medications that patient has
        [ValidateNever]
        public IEnumerable<Medication> PatientMedication { get; set; }

        //Medications to add/edit
        [ValidateNever]
        public Medication Medication { get; set; }
    }
}
