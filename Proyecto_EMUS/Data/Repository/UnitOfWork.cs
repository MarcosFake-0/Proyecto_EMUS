using Proyecto_EMUS.Data.Repository.Interfaces;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;

        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;

            Conditions = new ConditionsRepository(_db);
            Doctor = new DoctorRepository(_db);
            Patient = new PatientRepository(_db);
            Specialty = new SpecialtyRepository(_db);
            DoctorSpecialty = new DoctorSpecialtyRepository(_db);
            Treatment = new TreatmentRepository(_db);
            Drug = new DrugRepository(_db);
            ClinicalHistory = new ClinicalHistoryRepository(_db);
            ClinicalHistoryNote = new ClinicalHistoryNoteRepository(_db);
            LaboratoryExam = new LaboratoryExamRepository(_db);
            Medication = new MedicationRepository(_db);
        }


        public IConditionsRepository Conditions { get; private set; }
        public IDoctorRepository Doctor { get; private set; }
        public IPatientRepository Patient { get; private set; }
        public ISpecialtyRepository Specialty { get; private set; }
        public IDoctorSpecialtyRepository DoctorSpecialty { get; private set; }
        public ITreatmentRepository Treatment { get; private set; }
        public IDrugRepository Drug { get; private set; }
        public IClinicalHistoryRepository ClinicalHistory { get; private set; }
        public IClinicalHistoryNoteRepository ClinicalHistoryNote { get; private set; }
        public ILaboratoryExamRepository LaboratoryExam { get; private set; }
        public IMedicationRepository Medication { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
