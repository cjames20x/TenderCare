using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class TenderCareDbContext(DbContextOptions<TenderCareDbContext> options) : DbContext(options)
    {
        // 1. Your DbSets (Table Definitions)
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Immunization> Immunizations { get; set; }

        // 2. Put the code RIGHT HERE
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(e => {
                e.ToTable("Patients");
                e.HasKey(p => p.PatientID);
            });

            modelBuilder.Entity<Appointment>(e => {
                e.ToTable("Appointments");
                e.HasKey(a => a.AppointmentID);
            });

            modelBuilder.Entity<MedicalRecord>(e => {
                e.ToTable("MedicalRecords");
                e.HasKey(m => m.RecordID);
            });

            modelBuilder.Entity<Immunization>(e => {
                e.ToTable("Immunizations");
                e.HasKey(i => i.ImmunizationID);
            });
        }
    } // End of Class
}