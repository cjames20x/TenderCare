using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, bool rememberMe)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(string firstName, string lastName, string email, string phone, string password, string confirmPassword)
        {
            return View("Login");
        }
    }
}