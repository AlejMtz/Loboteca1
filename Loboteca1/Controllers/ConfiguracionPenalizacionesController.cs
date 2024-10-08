using Loboteca1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Loboteca1.Controllers
{
    public class ConfiguracionPenalizacionesController : Controller
    {
        private readonly LobotecaContext _context;

        public ConfiguracionPenalizacionesController(LobotecaContext context)
        {
            _context = context;
        }

        // Método para listar todas las penalizaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.configuracion_penalizaciones.ToListAsync());
        }

        // Acción para mostrar el formulario de creación
        public IActionResult Create()
        {
            return View();
        }

        // Acción para manejar el POST del formulario de creación
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConfiguracionPenalizacionesModel penalizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penalizacion); // Agregar la nueva penalización
                await _context.SaveChangesAsync(); // Guardar en la base de datos
                return RedirectToAction(nameof(Index)); // Redirigir al índice
            }
            return View(penalizacion); // Si hay errores, devolver la vista
        }

        // Método para editar una penalización
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Si no se proporciona id
            }

            var penalizacion = await _context.configuracion_penalizaciones.FindAsync(id); // Buscar la penalización
            if (penalizacion == null)
            {
                return NotFound(); // Si no se encuentra la penalización
            }

            return View(penalizacion); // Devolver la vista con el modelo encontrado
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ConfiguracionPenalizacionesModel penalizacion)
        {
            if (id != penalizacion.id_penalizacion)
            {
                return NotFound(); // Si el id no coincide
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penalizacion); // Actualizar la penalización
                    await _context.SaveChangesAsync(); // Guardar los cambios
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenalizacionExists(penalizacion.id_penalizacion))
                    {
                        return NotFound(); // Si la penalización no existe
                    }
                    else
                    {
                        throw; // Lanzar excepción si hay otro error
                    }
                }
                return RedirectToAction(nameof(Index)); // Redirigir al índice después de guardar cambios
            }

            return View(penalizacion); // Si hay errores, devolver la vista con el modelo
        }

        // Método para eliminar una penalización
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Si no se proporciona id
            }

            var penalizacion = await _context.configuracion_penalizaciones
                .FirstOrDefaultAsync(m => m.id_penalizacion == id); // Buscar la penalización
            if (penalizacion == null)
            {
                return NotFound(); // Si no se encuentra la penalización
            }

            return View(penalizacion); // Devolver la vista con el modelo encontrado
        }

        // Acción para confirmar la eliminación de una penalización
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penalizacion = await _context.configuracion_penalizaciones.FindAsync(id); // Buscar la penalización por id
            _context.configuracion_penalizaciones.Remove(penalizacion); // Eliminar la penalización
            await _context.SaveChangesAsync(); // Guardar los cambios
            return RedirectToAction(nameof(Index)); // Redirigir al índice
        }

        // Verificar si una penalización existe
        private bool PenalizacionExists(int id)
        {
            return _context.configuracion_penalizaciones.Any(e => e.id_penalizacion == id); // Verificar si el id existe en la base de datos
        }
    }
}
