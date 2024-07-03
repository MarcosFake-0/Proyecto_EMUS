using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<PatientMedication> PatientMedication { get; set;}
    }
}
