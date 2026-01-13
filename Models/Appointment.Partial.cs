using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public partial class Appointment
    {
        [NotMapped] // This prevents SQL from trying to find a "DisplayDate" column
        public string DisplayDate => AppointmentDate.ToString("g");
    }
}