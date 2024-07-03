using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<PatientTreatment> PatientTreatments { get; set;}
    }
}
