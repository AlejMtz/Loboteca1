using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class InventarioController : Controller
    {
        // Acción para mostrar la vista de inventario
        [HttpGet]
        public IActionResult Inventario()
        {
            return View();
        }

        // Acción para procesar el botón "Más datos"
        [HttpPost]
        public IActionResult MasDatos(string titulo)
        {
            // Aquí puedes agregar la lógica para mostrar más detalles del libro
            // Por ahora redirige a la misma vista
            return RedirectToAction("Inventario");
        }
    }
}
