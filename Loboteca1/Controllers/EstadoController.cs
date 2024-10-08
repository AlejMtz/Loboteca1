using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class EstadoController : Controller
    {
        private readonly LobotecaContext _context;

        public EstadoController(LobotecaContext context)
        {
            _context = context;
        }

        // Listar todos los estados
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estado.ToListAsync()); // Cambiado a 'Estado'
        }

        // Mostrar formulario para crear un nuevo estado
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EstadoModel estado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        // Editar un estado existente
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado.FindAsync(id); // Cambiado a 'Estado'
            if (estado == null)
            {
                return NotFound();
            }
            return View(estado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EstadoModel estado)
        {
            if (id != estado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoExists(estado.Id))
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
            return View(estado);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado // Cambiado a 'Estado'
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _context.Estado.FindAsync(id); // Cambiado a 'Estado'
            _context.Estado.Remove(estado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoExists(int id)
        {
            return _context.Estado.Any(e => e.Id == id); // Cambiado a 'Estado'
        }
    }
}
