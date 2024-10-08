using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class LibrosController : Controller
    {
        public IActionResult Libros()
        {
            return View();
        }

        // Puedes agregar otros métodos si necesitas manejar más funciones, por ejemplo, si deseas cargar PDF u otra acción
    }
}
