using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public partial class Appointment
    {
        [NotMapped]
        public string DisplayDate => AppointmentDate?.ToString("g") ?? "TBD";
    }
}