using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class ClinicalHistory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }


        public int PatientId { get; set; }
    }
}
