using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class RevistasController : Controller
    {
        [HttpGet]
        public IActionResult Revistas() // Verifica que el nombre de la acción sea correcto
        {
            return View(); // Esto cargará la vista Revistas.cshtml
        }

        [HttpPost]
        public IActionResult CrearRevista(string titulo, string autor, string isbn, string editorial, DateTime fechaPublicacion, string genero, int edicion, int paginas, string frecuenciaPublicacion, IFormFile portada)
        {
            if (ModelState.IsValid)
            {
                // Lógica para guardar la revista
                return RedirectToAction("Revistas");
            }
            return View();
        }
    }
}
