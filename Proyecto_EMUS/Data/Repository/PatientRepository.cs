using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private ApplicationDBContext _applicationDB;

        public PatientRepository(ApplicationDBContext db) : base(db)
        {
            _applicationDB = db;
        }

        public void Update(Patient patient)
        {
            _applicationDB.Patient.Update(patient);
        }
    }
}
