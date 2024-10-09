using Microsoft.AspNetCore.Mvc;

namespace Loboteca1.Controllers
{
    public class NegociosController : Controller
    {
        public IActionResult Negocios()
        {
            return View();
        }
    }
}
