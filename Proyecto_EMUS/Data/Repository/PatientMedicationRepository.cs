using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class PatientMedicationRepository : Repository<PatientMedication>, IPatientMedicationRepository
    {

        private ApplicationDBContext _applicationDB;

        public PatientMedicationRepository(ApplicationDBContext db) : base(db)
        {
            _applicationDB = db;
        }

        public void Update(PatientMedication patientMedication)
        {
            _applicationDB.PatientMedication.Update(patientMedication);
        }
    }
}
