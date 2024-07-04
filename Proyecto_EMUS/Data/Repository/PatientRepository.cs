using Microsoft.EntityFrameworkCore;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;
using System.Linq.Expressions;

namespace Proyecto_EMUS.Data.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private ApplicationDBContext _db;

        public PatientRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Patient> GetAllByDoctor(Expression<Func<Patient, bool>> filter, string? includeProperties = null)
        {
            IQueryable<Patient> query = _db.Patient;

            query = query.Where(filter);

            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return query.ToList();
        }

        public void Update(Patient patient)
        {
            _db.Patient.Update(patient);
        }
    }
}
