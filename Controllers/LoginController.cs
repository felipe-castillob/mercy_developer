using Microsoft.AspNetCore.Mvc;
using mercy_developer.Models;
using mercy_developer.Recursos;
using mercy_developer.Servicios.Contrato;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace mercy_developer.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioServicio = usuarioService;
        }

        /**
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrarse()
        {
            return View();
        }
        **/ 

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string correo, string password)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(correo, password);

            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontro el Usuario";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Index", "Home");
        }
    }
}
