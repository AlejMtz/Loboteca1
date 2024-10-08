using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class RevistaController : Controller
    {
        private readonly LobotecaContext _context;

        public RevistaController(LobotecaContext context)
        {
            _context = context;
        }

        // Listar todas las revistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Revistas.ToListAsync());
        }

        // Mostrar formulario para crear una nueva revista
        public IActionResult Create()
        {
            return View();
        }

        // Guardar la nueva revista en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RevistaModel revista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(revista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(revista);
        }

        // Editar una revista existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revista = await _context.Revistas.FindAsync(id);
            if (revista == null)
            {
                return NotFound();
            }
            return View(revista);
        }

        // Guardar los cambios de edición en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RevistaModel revista)
        {
            if (id != revista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(revista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RevistaExists(revista.Id))
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
            return View(revista);
        }

        // Eliminar una revista
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var revista = await _context.Revistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (revista == null)
            {
                return NotFound();
            }

            return View(revista);
        }

        // Confirmar eliminación de la revista
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var revista = await _context.Revistas.FindAsync(id);
            _context.Revistas.Remove(revista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RevistaExists(int id)
        {
            return _context.Revistas.Any(e => e.Id == id);
        }
    }
}
