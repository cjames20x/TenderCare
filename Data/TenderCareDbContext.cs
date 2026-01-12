using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class TenderCareDbContext : DbContext
    {
        public TenderCareDbContext(DbContextOptions<TenderCareDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>(e => { e.ToTable("Patients"); e.HasKey(p => p.PatientID); });
            modelBuilder.Entity<Appointment>(e => { e.ToTable("Appointments"); e.HasKey(a => a.AppointmentID); });
        }
    }
}