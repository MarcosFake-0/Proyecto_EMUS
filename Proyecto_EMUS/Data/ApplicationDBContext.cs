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

        public DbSet<DoctorSpecialty> DoctorSpecialty { get; set; }
    }
}
