using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository.Interfaces
{
    public interface IClinicalHistoryNoteRepository : IRepository<ClinicalHistoryNote>
    {
        void Update(ClinicalHistoryNote clinicalHistoryNote);
    }
}
