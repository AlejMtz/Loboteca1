using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class EditorialController : Controller
    {
        private readonly LobotecaContext _context;

        public EditorialController(LobotecaContext context)
        {
            _context = context;
        }

        // Listado de editoriales
        public async Task<IActionResult> Index()
        {
            var editoriales = await _context.Editorial.ToListAsync();
            return View(editoriales);
        }

        // Crear Editorial - GET
        public IActionResult Create()
        {
            ViewBag.Estados = new[] { "Disponible", "No Disponible" }; // Valores del ComboBox
            return View();
        }

        // Crear Editorial - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EditorialModel editorial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(editorial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Estados = new[] { "Disponible", "No Disponible" };
            return View(editorial);
        }

        // Editar Editorial - GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial.FindAsync(id);
            if (editorial == null)
            {
                return NotFound();
            }

            ViewBag.Estados = new[] { "Disponible", "No Disponible" };
            return View(editorial);
        }

        // Editar Editorial - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditorialModel editorial)
        {
            if (id != editorial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(editorial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EditorialExists(editorial.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Estados = new[] { "Disponible", "No Disponible" };
            return View(editorial);
        }

        // Eliminar Editorial - GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial.FirstOrDefaultAsync(m => m.Id == id);
            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        // Eliminar Editorial - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editorial = await _context.Editorial.FindAsync(id);
            _context.Editorial.Remove(editorial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialExists(int id)
        {
            return _context.Editorial.Any(e => e.Id == id);
        }
    }
}
