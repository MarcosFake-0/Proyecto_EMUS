using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class ConditionsRepository : Repository<Conditions>, IConditionsRepository
    {
        private ApplicationDBContext _applicationDB;

        public ConditionsRepository(ApplicationDBContext db) : base(db)
        {
            _applicationDB = db;
        }

        public void Update(Conditions Conditions)
        {
            _applicationDB.Conditions.Update(Conditions);
        }
    }
}
