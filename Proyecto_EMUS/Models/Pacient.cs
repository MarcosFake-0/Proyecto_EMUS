using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class Pacient
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



        
    }
}
