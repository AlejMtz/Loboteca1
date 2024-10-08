using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class AutorELibroController : Controller
    {
        private readonly LobotecaContext _context;

        public AutorELibroController(LobotecaContext context)
        {
            _context = context;
        }

        // Listar todas las relaciones Autor - E-Libro
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutorELibros.ToListAsync());
        }

        // Mostrar formulario para crear una nueva relación Autor - E-Libro
        public IActionResult Create()
        {
            return View();
        }

        // Guardar la nueva relación Autor - E-Libro en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorELibroModel autorELibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorELibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autorELibro);
        }

        // Editar una relación Autor - E-Libro existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorELibro = await _context.AutorELibros.FindAsync(id);
            if (autorELibro == null)
            {
                return NotFound();
            }
            return View(autorELibro);
        }

        // Guardar los cambios de edición en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutorELibroModel autorELibro)
        {
            if (id != autorELibro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorELibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorELibroExists(autorELibro.Id))
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
            return View(autorELibro);
        }

        // Eliminar una relación Autor - E-Libro
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorELibro = await _context.AutorELibros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autorELibro == null)
            {
                return NotFound();
            }

            return View(autorELibro);
        }

        // Confirmar eliminación de la relación Autor - E-Libro
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorELibro = await _context.AutorELibros.FindAsync(id);
            _context.AutorELibros.Remove(autorELibro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorELibroExists(int id)
        {
            return _context.AutorELibros.Any(e => e.Id == id);
        }
    }
}
