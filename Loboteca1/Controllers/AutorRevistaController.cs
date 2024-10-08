using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class AutorRevistaController : Controller
    {
        private readonly LobotecaContext _context;

        public AutorRevistaController(LobotecaContext context)
        {
            _context = context;
        }

        // Listar todas las relaciones Autor - Revista
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutorRevistas.ToListAsync());
        }

        // Mostrar formulario para crear una nueva relación Autor - Revista
        public IActionResult Create()
        {
            return View();
        }

        // Guardar la nueva relación Autor - Revista en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorRevistaModel autorRevista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorRevista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autorRevista);
        }

        // Editar una relación Autor - Revista existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorRevista = await _context.AutorRevistas.FindAsync(id);
            if (autorRevista == null)
            {
                return NotFound();
            }
            return View(autorRevista);
        }

        // Guardar los cambios de edición en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutorRevistaModel autorRevista)
        {
            if (id != autorRevista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorRevista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorRevistaExists(autorRevista.Id))
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
            return View(autorRevista);
        }

        // Eliminar una relación Autor - Revista
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorRevista = await _context.AutorRevistas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autorRevista == null)
            {
                return NotFound();
            }

            return View(autorRevista);
        }

        // Confirmar eliminación de la relación Autor - Revista
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorRevista = await _context.AutorRevistas.FindAsync(id);
            _context.AutorRevistas.Remove(autorRevista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorRevistaExists(int id)
        {
            return _context.AutorRevistas.Any(e => e.Id == id);
        }
    }
}
