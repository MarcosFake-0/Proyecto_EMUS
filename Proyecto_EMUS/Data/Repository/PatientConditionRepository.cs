using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class PatientConditionRepository : Repository<PatientCondition>, IPatientConditionRepository
    {
        private ApplicationDBContext _applicationDB;

        public PatientConditionRepository(ApplicationDBContext db) : base(db)
        {
            _applicationDB = db;
        }

        public void Update(PatientCondition patientCondition)
        {
            _applicationDB.PatientConditions.Update(patientCondition);
        }
    }
}
