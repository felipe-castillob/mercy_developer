using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mercy_developer.Models;

namespace mercy_developer.Controllers
{
    public class AuthController : Controller
    {
        private readonly MercyDeveloperContext _context;

        public AuthController(MercyDeveloperContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string correo, string password)
        {
            var user = _context.Usuarios.SingleOrDefault(u => u.Correo == correo && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Correo", correo);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid correo or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
