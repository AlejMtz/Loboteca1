using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class CarreraController : Controller
    {
        private readonly LobotecaContext _context;

        public CarreraController(LobotecaContext context)
        {
            _context = context;
        }

        // Listado de carreras
        public async Task<IActionResult> Index()
        {
            var carreras = await _context.Carreras.Include(c => c.Estado).ToListAsync();
            return View(carreras);
        }

        // Acción para mostrar el formulario de creación
        public async Task<IActionResult> Create()
        {
            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre");
            return View();
        }

        // Acción para manejar el POST del formulario de creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarreraModel carrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre", carrera.Id_estado);
            return View(carrera);
        }

        // Método para editar una carrera
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }

            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre", carrera.Id_estado);
            return View(carrera);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CarreraModel carrera)
        {
            if (id != carrera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarreraExists(carrera.Id))
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

            ViewBag.EstadoId = new SelectList(await _context.Estado.ToListAsync(), "Id", "Nombre", carrera.Id_estado);
            return View(carrera);
        }

        // Acción para eliminar una carrera
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrera = await _context.Carreras
                .Include(c => c.Estado)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrera == null)
            {
                return NotFound();
            }

            return View(carrera);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            _context.Carreras.Remove(carrera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarreraExists(int id)
        {
            return _context.Carreras.Any(e => e.Id == id);
        }
    }
}
