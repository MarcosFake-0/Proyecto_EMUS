using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_EMUS.Models;

namespace Proyecto_EMUS.Data
{
    public class ApplicationDBContext : IdentityDbContext
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

        public DbSet<ClinicalHistoryNote> ClinicalHistoryNotes { get; set; }

        public DbSet<LaboratoryExam> LaboratoryExams { get; set; }

        public DbSet<Medication> Medications { get; set; }

        public DbSet<PatientCondition> PatientConditions { get; set; }
        public DbSet<PatientMedication> PatientMedication { get; set; }
        public DbSet<PatientTreatment> PatientTreatment { get; set; }
        public DbSet<PatientLaboratoryExam> PatientLaboratoryExam { get; set; }


        // Recuerde hacer la migración antes de nada <==================!!!!!!!!!!!!!!!!!
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<DoctorUser> DoctorUser {  get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Doctor
            modelBuilder.Entity<Doctor>()
                .Property(d => d.GMCNumber)
                .ValueGeneratedNever();

            //ClinicalHistoryNotes
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.ClinicalHistoryNotes)
                .WithOne(ch => ch.Patient)
                .HasForeignKey(ch => ch.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            //PatientTreatment
            modelBuilder.Entity<PatientTreatment>()
                .HasKey(pt => new { pt.IdPatient, pt.IdTreatment });

            modelBuilder.Entity<PatientTreatment>()
                .HasOne(pt => pt.Patient)
                .WithMany(p => p.PatientTreatments)
                .HasForeignKey(pt => pt.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientTreatment>()
                .HasOne(pt => pt.Treatment)
                .WithMany()
                .HasForeignKey(pt => pt.IdTreatment)
                .OnDelete(DeleteBehavior.Cascade);

            //PatientMedication
            modelBuilder.Entity<PatientMedication>()
                .HasKey(pm => new { pm.IdPatient, pm.IdMedication });

            modelBuilder.Entity<PatientMedication>()
                .HasOne(pm => pm.Patient)
                .WithMany(p => p.PatientMedication)
                .HasForeignKey(pm => pm.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientMedication>()
                .HasOne(pm => pm.Medication)
                .WithMany()
                .HasForeignKey(pm => pm.IdMedication)
                .OnDelete(DeleteBehavior.Cascade);

            //PatientCondition
            modelBuilder.Entity<PatientCondition>()
                .HasKey(pc => new { pc.IdPatient, pc.IdCondition });

            modelBuilder.Entity<PatientCondition>()
                .HasOne(pc => pc.Patient)
                .WithMany(p => p.PatientConditions)
                .HasForeignKey(pc => pc.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientCondition>()
                .HasOne(pc => pc.Conditions)
                .WithMany()
                .HasForeignKey(pc => pc.IdCondition)
                .OnDelete(DeleteBehavior.Cascade);

            //PatientLaboratoryExam
            modelBuilder.Entity<PatientLaboratoryExam>()
                .HasKey(pl => pl.Id);

            modelBuilder.Entity<PatientLaboratoryExam>()
                .HasOne(pl => pl.Patient)
                .WithMany(p => p.PatientLaboratoryExams)
                .HasForeignKey(pl => pl.IdPatient)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PatientLaboratoryExam>()
                .HasOne(pl => pl.LaboratoryExam)
                .WithMany()
                .HasForeignKey(pl => pl.IdLaboratoryExam)
                .OnDelete(DeleteBehavior.Cascade);

            //DoctorSpecialty
            modelBuilder.Entity<DoctorSpecialty>()
                .HasKey(ds => new { ds.GMCNumber, ds.IdSpecialty });

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecialties)
                .HasForeignKey(ds => ds.GMCNumber)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne(ds => ds.Specialty)
                .WithMany()
                .HasForeignKey(ds => ds.IdSpecialty)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

        }
    }
}
