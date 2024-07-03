using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class Doctor
    {
        [Key]
        public int GMCNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string? UrlImage { get; set; }

        public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; }
    }
}
