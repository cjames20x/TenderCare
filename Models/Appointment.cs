namespace Project.Models
{
    public partial class Appointment
    {
        public string AppointmentID { get; set; } = string.Empty;
        public string PatientID { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Pending";
        public virtual Patient? Patient { get; set; }
    }
}