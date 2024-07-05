using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class Patient
    {

        [Key]
        [Display(Name = "Cédula")]
        public string Id { get; set; }

        [Required]
        [Display(Name ="Fecha de nacimiento")]
        public DateOnly DayOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Primer Nombre")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Primer apellido")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Estado cívil")]
        public string CivilStatus { get; set; }

        [Display(Name = "Doctor")]
        public int? AttendingDoctor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Última fecha de atención")]
        public DateTime? LastAttendDate { get; set; }

        public ICollection<PatientCondition>? PatientConditions { get; set; }
        public ICollection<PatientMedication>? PatientMedication { get; set; }
        public ICollection<PatientTreatment>? PatientTreatments { get; set; }
        public ICollection<PatientLaboratoryExam>? PatientLaboratoryExams { get; set; }
        public ICollection<ClinicalHistoryNote>? ClinicalHistoryNotes { get; set; }



        private class AllowedValuesAttribute : ValidationAttribute
        {
            private readonly string[] _allowedValues;

            public AllowedValuesAttribute(params string[] allowedValues)
            {
                _allowedValues = allowedValues;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null && _allowedValues.Contains(value.ToString()))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"The field {validationContext.DisplayName} must be one of the following values: {string.Join(", ", _allowedValues)}.");
            }
        }
    }
}
