using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Linq;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly TenderCareDbContext _context;

        public HomeController(TenderCareDbContext context) => _context = context;

        public IActionResult Index() => View();
        public IActionResult Services() => View();

        [HttpPost]
        public IActionResult MakeAppointment(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if patient exists
                var patient = _context.Patients.FirstOrDefault(p => p.Email == model.Email)
                            ?? _context.Patients.FirstOrDefault(p => p.PatientName == model.PatientName);

                if (patient == null)
                {
                    patient = new Patient
                    {
                        PatientID = "P" + DateTime.Now.Ticks.ToString().Substring(10),
                        PatientName = model.PatientName,
                        GuardianName = model.GuardianName,
                        Email = model.Email,
                        Gender = model.Gender,
                        Address = model.Address,
                        DateOfBirth = model.DateOfBirth,
                        ContactNumber = model.ContactNumber
                    };
                    _context.Patients.Add(patient);
                    _context.SaveChanges(); // Must save patient first
                }

                var appointment = new Appointment
                {
                    AppointmentID = "A" + DateTime.Now.Ticks.ToString().Substring(10),
                    PatientID = patient.PatientID,
                    ServiceType = model.Service,
                    AppointmentDate = model.AppointmentDate
                };

                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                TempData["Success"] = "Appointment Saved Successfully!";
                return RedirectToAction("Services");
            }
            return View("Services", model);
        }
    }

    public class AppointmentModel
    {
        public string PatientName { get; set; } = string.Empty;
        public string GuardianName { get; set; } = string.Empty;
        public string Service { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
    }
}