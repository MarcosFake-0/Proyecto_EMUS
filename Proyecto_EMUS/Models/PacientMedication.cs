using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class PacientMedication
    {
        [Key]
        [Required]
        public int IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        public Patient Patient { get; set; }

        [Key]
        [Required]
        public int IdMedication { get; set; }

        [ForeignKey("IdMedication")]
        public Medication Medication { get; set; }

    }
}
