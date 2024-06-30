using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private ApplicationDBContext _applicationDB;

        public DoctorRepository(ApplicationDBContext db) : base(db)
        {
            _applicationDB = db;
        }

        public void Update(Doctor doctor)
        {
            _applicationDB.Doctor.Update(doctor);
        }
    
    }
}
