using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Proyecto_EMUS.Models.ViewModels
{
    public class PatientTreatmentVM
    {
        [ValidateNever]
        public Patient Patient {  get; set; }

        [ValidateNever]
        public List<Treatment> Treatments { get; set; }
    }
}
