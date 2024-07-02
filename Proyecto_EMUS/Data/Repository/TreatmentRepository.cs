using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        private ApplicationDBContext _applicationDB;

        public TreatmentRepository(ApplicationDBContext db) : base(db) 
        { 
            _applicationDB = db;
        }

        public void Update(Treatment treatment) 
        {
            _applicationDB.Treatment.Update(treatment);
        }
    }
}
