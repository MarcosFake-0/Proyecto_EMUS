using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class DoctorSpecialty
    {

        [Key]
        [Column(Order =0)]
        public int GMCNumber { get; set; }

        [ForeignKey("GMCNumber")]
        public Doctor Doctor { get; set; }


        [Key]
        [Column(Order =1)]
        public int IdSpecialty { get; set; }

        [ForeignKey("IdSpecialty")]
        public Specialty Specialty { get; set; }
    }
}
