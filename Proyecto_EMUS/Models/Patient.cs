using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class Patient
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly DayOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string CivilStatus { get; set; }

        public int AttendingDoctor { get; set; }

        [ForeignKey("AttendingDoctor")]
        public Doctor Doctor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime LastAttendDate { get; set; }

        public ICollection<PatientCondition> PatientConditions { get; set; }
        public ICollection<PatientMedication> PatientMedication { get; set;}
        public ICollection<PatientTreatment> PatientTreatments { get; set;}
        public ICollection<PatientLaboratoryExam> PatientLaboratoryExams { get; set; }
    }
}
