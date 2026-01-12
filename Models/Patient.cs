using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Patient
    {
        [Key]
        public string PatientID { get; set; } = string.Empty;

        [Required]
        public string PatientName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        [Required]
        public string GuardianName { get; set; } = string.Empty;

        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<Immunization> Immunizations { get; set; } = new List<Immunization>();
    }

    public class Appointment
    {
        [Key]
        public string AppointmentID { get; set; } = string.Empty;
        public string PatientID { get; set; } = string.Empty;
        public string? ServiceType { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public string? Status { get; set; }

        public virtual Patient? Patient { get; set; }
    }

    public class MedicalRecord
    {
        [Key]
        public string RecordID { get; set; } = string.Empty;
        public string PatientID { get; set; } = string.Empty;
        public string? ServiceType { get; set; }
        public string? Diagnosis { get; set; }
        public string? Notes { get; set; }
        public string? DoctorName { get; set; }
        public DateTime? DateRecorded { get; set; }

        public virtual Patient? Patient { get; set; }
    }

    public class Immunization
    {
        [Key]
        public string ImmunizationID { get; set; } = string.Empty;
        public string PatientID { get; set; } = string.Empty;
        public string? VaccineName { get; set; }
        public string? DoseNumber { get; set; }
        public DateTime? DateAdministered { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string? Status { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}