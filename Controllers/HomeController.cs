using Microsoft.AspNetCore.Mvc;

namespace TenderCare.Controllers
{
    public class HomeController : Controller
    {
        // Home Page
        public IActionResult Index()
        {
            return View();
        }

        // Services Page
        public IActionResult Services()
        {
            return View();
        }

        // About Us Page
        public IActionResult AboutUs()
        {
            return View();
        }

        // Handle Appointment Form Submission
        [HttpPost]
        public IActionResult MakeAppointment(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                // TODO: Save appointment to database
                // Example: _context.Appointments.Add(model);
                // _context.SaveChanges();

                // Redirect to success page or show success message
                TempData["Success"] = "Appointment created successfully!";
                return RedirectToAction("Services");
            }

            return View("Services", model);
        }

        // Error Page
        public IActionResult Error()
        {
            return View();
        }
    }

    // Appointment Model
    public class AppointmentModel
    {
        public string PatientName { get; set; }
        public string GuardianName { get; set; }
        public string Service { get; set; }
        public string Email { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}