using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
