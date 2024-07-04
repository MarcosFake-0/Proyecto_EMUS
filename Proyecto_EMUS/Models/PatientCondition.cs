using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class PatientCondition
    {
        [Key]
        [Column(Order = 0)]
        public string IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        public Patient Patient { get; set; }

        [Key]
        [Column(Order = 1)]
        public int IdCondition { get; set; }

        [ForeignKey("IdCondition")]
        public Conditions Conditions { get; set;}

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int CreatedByDoctorId { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
