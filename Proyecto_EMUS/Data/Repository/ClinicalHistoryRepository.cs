using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class ClinicalHistoryRepository : Repository<ClinicalHistory>, IClinicalHistoryRepository
    {
        private ApplicationDBContext _db;

        public ClinicalHistoryRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ClinicalHistory clinicalHistory)
        {
            _db.ClinicalHistories.Update(clinicalHistory);
        }
    }
}
