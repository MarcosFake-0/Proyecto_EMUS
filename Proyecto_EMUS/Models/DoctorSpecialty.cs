using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class DoctorSpecialty
    {
        [ForeignKey("Doctor")]
        [Key]
        [Required]
        public int GMCNumber { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey("Specialty")]
        [Key]
        [Required]
        public int IdSpecialty { get; set; }

        public Specialty Specialty { get; set; }
    }
}
