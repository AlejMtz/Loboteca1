using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class NegociosController : Controller
    {
        public IActionResult Negocios()
        {
            return View();
        }

        // Acción que recibe el PDF seleccionado
        public IActionResult LeerPDF(string pdf)
        {
            ViewBag.PdfPath = "/pdfs/" + pdf; // Ruta dinámica del PDF seleccionado
            return View();
        }
    }
}
