using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_EMUS.Areas.Medicine.Controllers;

namespace Proyecto_EMUS.Models.ViewModels
{
    public class PatientTreatmentVM
    {
        //Patient who will to add the treatment
        [ValidateNever]
        public Patient Patient {  get; set; }

        //All tratments that patient doesn't has 
        [ValidateNever]
        public IEnumerable<SelectListItem> Treatments { get; set; }

        //All treatments that patient has
        [ValidateNever]
        public IEnumerable<Treatment> PatientTreatments { get; set; }

        //Treatment to add/edit
        [ValidateNever]
        public Treatment Treatment { get; set; }
    }
}
