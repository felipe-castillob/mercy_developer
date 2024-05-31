using Microsoft.AspNetCore.Mvc;

namespace mercy_developer.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
