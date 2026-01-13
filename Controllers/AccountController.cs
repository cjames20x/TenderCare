using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using System.Linq;

namespace Project.Controllers
{
    public class AccountController : Controller
    {
        private readonly TenderCareDbContext _context;

        public AccountController(TenderCareDbContext context)
        {
            _context = context;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // 1. SECRET ADMIN CHECK
            // You can change these to your preferred secret email and password
            if (email == "admin@tendercare.com" && password == "admin123")
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            // 2. REGULAR USER CHECK
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                // Successful Login redirects to Services page
                return RedirectToAction("Services", "Home");
            }

            ViewBag.Error = "Invalid Login credentials.";
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user, string confirmPassword)
        {
            if (user.Password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View("Login");
            }

            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Login");
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}