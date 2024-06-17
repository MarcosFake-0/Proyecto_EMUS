using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class Specialty
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }    
    }
}
