using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        private ApplicationDBContext _applicationDB;

        public SpecialtyRepository(ApplicationDBContext db) : base(db)
        {
            _applicationDB = db;
        }

        public void Update(Specialty specialty)
        {
            _applicationDB.Specialty.Update(specialty);
        }

    }
}
