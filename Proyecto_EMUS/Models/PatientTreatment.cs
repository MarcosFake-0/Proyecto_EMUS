using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class PatientTreatment
    {

        [Key]
        [Column(Order = 0)]
        public string IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        public Patient Patient { get; set; }


        [Key]
        [Column(Order = 1)]
        public int IdTreatment { get; set; }

        [ForeignKey("IdTreatment")]
        public Treatment Treatment { get; set; }

    }
}
