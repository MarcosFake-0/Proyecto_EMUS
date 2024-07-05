using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models.ViewModels
{
    public class DoctorVM
    {
        //Doctor who will to add/edit
        [Required]
        public Doctor Doctor { get; set; }

        //All specialties that doctor doesn't has 
        //If is creating, this is all specialties
        [ValidateNever]
        public IEnumerable<SelectListItem> Specialties { get; set; }

        //All specialties that doctor has
        [ValidateNever]
        public IEnumerable<Specialty> DoctorSpecialties { get; set; }

        //Specialty to add/edit
        [ValidateNever]
        public Specialty? Specialty { get; set; }

        public bool IsCreated { get; set; }
    }
}
