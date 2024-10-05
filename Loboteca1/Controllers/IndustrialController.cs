using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class IndustrialController : Controller
    {
        // Acción para mostrar la vista de Ingeniería en Industrial
        [HttpGet]
        public IActionResult Industrial()
        {
            return View();
        }
    }
}
