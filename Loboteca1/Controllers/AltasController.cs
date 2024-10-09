using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class AltasController : Controller
    {
        // Acción para mostrar la vista de Altas
        [HttpGet]
        public IActionResult Altas()
        {
            return View();
        }

        // Acción para procesar el formulario de altas
        [HttpPost]
        public IActionResult SubirLibro(string titulo, string autor, string isbn, string editorial, string fechaPublicacion, string genero)
        {
            // Aquí agregarías la lógica para guardar el libro en la base de datos
            // Por ahora redirige a la misma vista
            return RedirectToAction("Altas");
        }
    }
}
