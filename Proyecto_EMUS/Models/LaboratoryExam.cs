using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class LaboratoryExam
    {
        [Key]
        public int Id { get; set; }

        [Required] 
        public string Name { get; set; }

        public string? Description { get; set; } 

    }
}
