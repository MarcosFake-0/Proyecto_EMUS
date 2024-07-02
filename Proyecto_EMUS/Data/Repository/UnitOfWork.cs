using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _applicationDB;

        public UnitOfWork(ApplicationDBContext db)
        {
            _applicationDB = db;

            Conditions = new ConditionsRepository(_applicationDB);
            Doctor = new DoctorRepository(_applicationDB);
            Patient = new PatientRepository(_applicationDB);
            Specialty = new SpecialtyRepository(_applicationDB);
            Treatment = new TreatmentRepository(_applicationDB);
        }

        public IConditionsRepository Conditions { get; private set; }
        public IDoctorRepository Doctor { get; private set; }
        public IPatientRepository Patient { get; private set; }
        public ISpecialtyRepository Specialty { get; private set; }
        public IDoctorSpecialtyRepository DoctorSpecialty { get; private set; }

        public ITreatmentRepository Treatment { get; private set; }

        public void Save()
        {
            _applicationDB.SaveChanges();
        }

    }
}
