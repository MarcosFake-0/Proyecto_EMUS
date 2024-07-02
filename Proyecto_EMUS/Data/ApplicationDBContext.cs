using Microsoft.EntityFrameworkCore;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Conditions> Conditions { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<Patient> Patient { get; set; }

        public DbSet<Specialty> Specialty { get; set; }

        public DbSet<Treatment> Treatment { get; set; }

        public DbSet<DoctorSpecialty> DoctorSpecialty { get; set; }

        public DbSet<ClinicalHistory> ClinicalHistories { get; set; }

        public DbSet<ClinicalHistoryNote> ClinicalHistoryNotes { get; set; }

        public DbSet<Drug> Drugs { get; set; }

        public DbSet<LaboratoryExam> LaboratoryExams { get; set; }

        public DbSet<Medication> Medications { get; set; }
    }
}
