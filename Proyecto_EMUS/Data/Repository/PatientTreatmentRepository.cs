using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class PatientTreatmentRepository : Repository<PatientTreatment>, IPatientTreatmentRepository
    {
        private ApplicationDBContext _applicationDB;

        public PatientTreatmentRepository(ApplicationDBContext db) : base(db)
        {
            _applicationDB = db;
        }

        public void Update(PatientTreatment patientTreatment)
        {
            _applicationDB.PatientTreatment.Update(patientTreatment);
        }
    }
}
