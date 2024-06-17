using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DayOfBirth { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string FistName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string CivilStatus { get; set; }

        [ForeignKey("Doctor")]
        public int AttendingDoctor { get; set; }

        
    }
}
