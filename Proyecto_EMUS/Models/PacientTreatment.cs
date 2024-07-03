using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class PacientTreatment
    {

        [Key]
        [Required]
        public int IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        public Patient Patient { get; set; }


        [Key]
        [Required]
        public int IdTreatment { get; set; }

        [ForeignKey("IdTreatment")]
        public Treatment Treatment { get; set; }
    }
}
