using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class AutorLibroController : Controller
    {
        private readonly LobotecaContext _context;

        public AutorLibroController(LobotecaContext context)
        {
            _context = context;
        }

        // Listar todas las relaciones Autor - Libro
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutorLibros.ToListAsync());
        }

        // Mostrar formulario para crear una nueva relación Autor - Libro
        public IActionResult Create()
        {
            return View();
        }

        // Guardar la nueva relación Autor - Libro en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorLibroModel autorLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autorLibro);
        }

        // Editar una relación Autor - Libro existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorLibro = await _context.AutorLibros.FindAsync(id);
            if (autorLibro == null)
            {
                return NotFound();
            }
            return View(autorLibro);
        }

        // Guardar los cambios de edición en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutorLibroModel autorLibro)
        {
            if (id != autorLibro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorLibroExists(autorLibro.Id))
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
            return View(autorLibro);
        }

        // Eliminar una relación Autor - Libro
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorLibro = await _context.AutorLibros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autorLibro == null)
            {
                return NotFound();
            }

            return View(autorLibro);
        }

        // Confirmar eliminación de la relación Autor - Libro
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorLibro = await _context.AutorLibros.FindAsync(id);
            _context.AutorLibros.Remove(autorLibro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorLibroExists(int id)
        {
            return _context.AutorLibros.Any(e => e.Id == id);
        }
    }
}
