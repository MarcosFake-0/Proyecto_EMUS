using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class PatientLaboratoryExam
    {
        [Key]

        public int Id { get; set; }

        public string IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        public Patient Patient { get; set; }

        public int IdLaboratoryExam { get; set; }

        [ForeignKey("IdLaboratoryExam")]
        public LaboratoryExam LaboratoryExam { get; set; }

        public string? FileUrl { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public int CreatedByDoctorId { get; set; }
    }
}
