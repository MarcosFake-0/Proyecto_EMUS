using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Proyecto_EMUS.Models.ViewModels
{
    public class DoctorVM
    {
        [ValidateNever]
        public Doctor Doctor { get; set; }

        [ValidateNever]
        public List<Specialty> Specialties { get; set; }
    }
}
