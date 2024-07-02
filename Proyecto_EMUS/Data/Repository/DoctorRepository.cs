﻿using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private ApplicationDBContext _db;

        public DoctorRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Doctor doctor)
        {
            _db.Doctor.Update(doctor);
        }
    
    }
}
