using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class MedicationRepository : Repository<Medication>, IMedicationRepository
    {
        private ApplicationDBContext _db;

        public MedicationRepository(ApplicationDBContext db) : base (db)
        {
            _db = db;
        }

        public void Update(Medication medication)
        {
            _db.Medications.Update(medication);
        }
    }
}
