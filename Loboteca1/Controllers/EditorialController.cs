using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var editoriales = await _context.Editorial.Include(e => e.Estado).ToListAsync();
            return View(editoriales);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre");
            return View();
        }

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
            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre", editorial.Id_Estado);
            return View(editorial);
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial.FindAsync(Id);
            if (editorial == null)
            {
                return NotFound();
            }

            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre", editorial.Id_Estado);
            return View(editorial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, EditorialModel editorial)
        {
            if (Id != editorial.Id)
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

            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre", editorial.Id_Estado);
            return View(editorial);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var editorial = await _context.Editorial
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (editorial == null)
            {
                return NotFound();
            }

            return View(editorial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var editorial = await _context.Editorial.FindAsync(Id);
            _context.Editorial.Remove(editorial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EditorialExists(int Id)
        {
            return _context.Editorial.Any(e => e.Id == Id);
        }
    }
}
