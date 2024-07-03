using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_EMUS.Models
{
    public class ClinicalHistoryNote
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public int ClinicalHistoryId { get; set; }

        [ForeignKey("ClinicalHistoryId")]
        public ClinicalHistory ClinicalHistory { get; set; }
    }
}
