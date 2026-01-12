using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class TenderCareDbContext : DbContext
    {
        public TenderCareDbContext(DbContextOptions<TenderCareDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Immunization> Immunizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patients");
                entity.HasKey(e => e.PatientID);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointments");
                entity.HasKey(e => e.AppointmentID);
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.Appointments)
                      .HasForeignKey(e => e.PatientID);
            });

            modelBuilder.Entity<MedicalRecord>(entity =>
            {
                entity.ToTable("MedicalRecords");
                entity.HasKey(e => e.RecordID);
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.MedicalRecords)
                      .HasForeignKey(e => e.PatientID);
            });

            modelBuilder.Entity<Immunization>(entity =>
            {
                entity.ToTable("Immunization");
                entity.HasKey(e => e.ImmunizationID);
                entity.HasOne(e => e.Patient)
                      .WithMany(p => p.Immunizations)
                      .HasForeignKey(e => e.PatientID);
            });
        }
    }
}