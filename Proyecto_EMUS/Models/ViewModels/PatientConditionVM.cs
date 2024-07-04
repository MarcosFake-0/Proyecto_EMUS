using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_EMUS.Areas.Admin.Controllers;

namespace Proyecto_EMUS.Models.ViewModels
{
    public class PatientConditionVM
    {
        //Patient who will to add the medication
        [ValidateNever]
        public Patient Patient {  get; set; }

        //All tratments that patient doesn't has 
        [ValidateNever]
        public IEnumerable<SelectListItem> Conditions { get; set; }

        //All medications that patient has
        [ValidateNever]
        public IEnumerable<Conditions> PatientCondition { get; set; }

        //Medications to add/edit
        [ValidateNever]
        public Conditions Condition { get; set; }
    }
}
