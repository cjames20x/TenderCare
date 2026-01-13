using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Add this

namespace Project.Models
{
    public class MedicalRecord
    {
        [Key]
        public string RecordID { get; set; } = string.Empty;

        [ForeignKey("Patient")] // Explicitly link the ID to the Navigation Property
        public string PatientID { get; set; } = string.Empty;

        public string ServiceType { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime DateRecorded { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}