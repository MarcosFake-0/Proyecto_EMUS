using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class PatientLaboratoryExamRepository : Repository<LaboratoryExam>, IPatientLaboratoryExamRepository
    {
        private ApplicationDBContext _db;

        public PatientLaboratoryExamRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PatientLaboratoryExam patientLaboratoryExam)
        {
            _db.PatientLaboratoryExam.Update(patientLaboratoryExam);
        }
    }
}
