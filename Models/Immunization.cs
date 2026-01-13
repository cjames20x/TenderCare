using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Immunization
    {
        [Key]
        public string ImmunizationID { get; set; } = string.Empty;
        public string PatientID { get; set; } = string.Empty;
        public string VaccineName { get; set; } = string.Empty;

        // Added these based on your requirement
        public int DoseNumber { get; set; }
        public DateTime DateAdministered { get; set; }
        public DateTime? NextDueDate { get; set; }
        public string Status { get; set; } = "Completed";

        public virtual Patient? Patient { get; set; }
    }
}