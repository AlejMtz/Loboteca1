using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class SancionesController : Controller
    {
        [HttpGet]
        public IActionResult Sanciones()
        {
            return View();
        }
    }
}
