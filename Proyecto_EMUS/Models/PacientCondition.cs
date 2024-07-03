using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class PacientCondition
    {
        [Key]
        [Required]
        public int IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        public Patient Patient { get; set; }

        [Key]
        [Required]
        public int IdCondition { get; set; }

        [ForeignKey("IdCondition")]
        public Conditions Conditions { get; set;}
    }
}
