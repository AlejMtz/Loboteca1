using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class ELibroController : Controller
    {
        private readonly LobotecaContext _context;

        public ELibroController(LobotecaContext context)
        {
            _context = context;
        }

        // Listar todos los e-libros
        public async Task<IActionResult> Index()
        {
            return View(await _context.ELibros.ToListAsync());
        }

        // Mostrar formulario para crear un nuevo e-libro
        public IActionResult Create()
        {
            return View();
        }

        // Guardar el nuevo e-libro en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ELibroModel eLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eLibro);
        }

        // Editar un e-libro existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eLibro = await _context.ELibros.FindAsync(id);
            if (eLibro == null)
            {
                return NotFound();
            }
            return View(eLibro);
        }

        // Guardar los cambios de edición en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ELibroModel eLibro)
        {
            if (id != eLibro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ELibroExists(eLibro.Id))
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
            return View(eLibro);
        }

        // Eliminar un e-libro
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eLibro = await _context.ELibros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eLibro == null)
            {
                return NotFound();
            }

            return View(eLibro);
        }

        // Confirmar eliminación del e-libro
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eLibro = await _context.ELibros.FindAsync(id);
            _context.ELibros.Remove(eLibro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ELibroExists(int id)
        {
            return _context.ELibros.Any(e => e.Id == id);
        }
    }
}
