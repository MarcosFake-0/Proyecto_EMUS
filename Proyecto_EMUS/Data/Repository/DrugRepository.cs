using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class DrugRepository : Repository<Drug>, IDrugRepository
    {
        private ApplicationDBContext _db;

        public DrugRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Drug drug)
        {
            _db.Drugs.Update(drug);
        }
    }
}
