using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class LaboratoryExamRepository : Repository<LaboratoryExam>, ILaboratoryExamRepository
    {
        private ApplicationDBContext _db;

        public LaboratoryExamRepository(ApplicationDBContext db) : base (db)
        {
            _db = db;
        }

        public void Update(LaboratoryExam laboratoryExam)
        {
            _db.LaboratoryExams.Update(laboratoryExam);
        }
    }
}
