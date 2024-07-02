using Microsoft.EntityFrameworkCore;
using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class DoctorSpecialtyRepository : Repository<DoctorSpecialty>, IDoctorSpecialtyRepository
    {
        ApplicationDBContext _db;

        public DoctorSpecialtyRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<DoctorSpecialty> GetAllByDoctorGMCNumber(int gmcNumber, string? includeProperties = null)
        {
            IQueryable<DoctorSpecialty> query = _db.DoctorSpecialty;

            query = query.Where(ds => ds.GMCNumber == gmcNumber);

            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return query.ToList();
        }

        public void Update(DoctorSpecialty doctorSpecialty)
        {
            _db.DoctorSpecialty.Update(doctorSpecialty);
        }
    }
}
