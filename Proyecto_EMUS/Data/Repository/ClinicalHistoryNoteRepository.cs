using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class ClinicalHistoryNoteRepository : Repository<ClinicalHistoryNote>, IClinicalHistoryNoteRepository
    {
        private ApplicationDBContext _db;

        public ClinicalHistoryNoteRepository(ApplicationDBContext db) : base (db)
        {
            _db = db;
        }

        public void Update(ClinicalHistoryNote clinicalHistoryNote)
        {
            _db.ClinicalHistoryNotes.Update(clinicalHistoryNote); 
        }
    }
}
