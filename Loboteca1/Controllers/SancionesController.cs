using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class SancionesController : Controller
    {
        private readonly LobotecaContext _context;

        public SancionesController(LobotecaContext context)
        {
            _context = context;
        }

        // Listar todas las sanciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sanciones.ToListAsync());
        }

        // Mostrar formulario para crear una nueva sanción
        public IActionResult Create()
        {
            return View();
        }

        // Guardar la nueva sanción en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SancionesModel sancion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sancion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sancion);
        }

        // Editar una sanción existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sanciones.FindAsync(id);
            if (sancion == null)
            {
                return NotFound();
            }
            return View(sancion);
        }

        // Guardar los cambios de edición en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SancionesModel sancion)
        {
            if (id != sancion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sancion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SancionExists(sancion.Id))
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
            return View(sancion);
        }

        // Eliminar una sanción
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sancion = await _context.Sanciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sancion == null)
            {
                return NotFound();
            }

            return View(sancion);
        }

        // Confirmar eliminación de la sanción
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sancion = await _context.Sanciones.FindAsync(id);
            _context.Sanciones.Remove(sancion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SancionExists(int id)
        {
            return _context.Sanciones.Any(e => e.Id == id);
        }
    }
}
