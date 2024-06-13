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
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Por favor, ingrese su correo y contraseña";
                return View();
            }

            var usuario = _context.Usuarios.SingleOrDefault(u => u.Correo == correo);

            if (usuario != null && usuario.VerifyPassword(password))
            {
                HttpContext.Session.SetString("Correo", correo);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Correo o contraseña inválidos";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
