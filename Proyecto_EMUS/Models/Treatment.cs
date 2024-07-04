using System.ComponentModel.DataAnnotations;

namespace Proyecto_EMUS.Models
{
    public class Treatment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Tratamiento")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
