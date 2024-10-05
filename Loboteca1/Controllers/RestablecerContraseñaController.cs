using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class RestablecerContraseñaController : Controller
    {
        [HttpGet]
        public IActionResult RestablecerContraseña()
        {
            return View("/Views/Login/RestablecerContraseña.cshtml"); // Ruta completa
        }

        [HttpPost]
        public IActionResult RestablecerContraseña(string username, string newPassword, string confirmPassword)
        {
            if (newPassword == confirmPassword)
            {
                return RedirectToAction("Login", "Login");
            }

            ViewBag.ErrorMessage = "Las contraseñas no coinciden.";
            return View("/Views/Login/RestablecerContraseña.cshtml"); // Ruta completa
        }
    }
}
