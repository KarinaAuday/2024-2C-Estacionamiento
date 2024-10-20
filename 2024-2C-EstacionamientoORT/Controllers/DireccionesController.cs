using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _2024_2C_EstacionamientoORT.Data;
using _2024_2C_EstacionamientoORT.Models;

namespace _2024_2C_EstacionamientoORT.Controllers
{
    public class DireccionesController : Controller
    {
        private readonly EstacionamientoContext _context;

        public DireccionesController(EstacionamientoContext context)
        {
            _context = context;
        }

        // GET: Direcciones
        public async Task<IActionResult> Index()
        {
            var estacionamientoContext = _context.Direccion.Include(d => d.Persona);
            return View(await estacionamientoContext.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccion
                .Include(d => d.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }


        

        // GET: Direcciones/Create
        public IActionResult Create(int ?id)
        {
            if (id.HasValue)
            {
                // Buscar la persona en la base de datos
                var persona = _context.Personas.FirstOrDefault(p => p.Id == id);

                if (persona != null)
                {
                    // Pasar el nombre y apellido a la vista
                    ViewBag.PersonaNombreCompleto = $"{persona.Nombre} {persona.Apellido}";
                    ViewBag.PersonaCrearId = id;
                }
                else
                {
                    // Manejar el caso en que la persona no exista
                    ViewBag.PersonaNombreCompleto = "Persona no encontrada";
                }
            }
            else
            {
                // Si no se proporcionó idPersona, cargar la lista de personas
                ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "NombreCompleto");
           
            }
            return View();

        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Calle,CodPostal,PersonaId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Apellido", direccion.PersonaId);
        
            return View(direccion);
        }

        // GET: Direcciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Apellido", direccion.PersonaId);
            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Calle,CodPostal,PersonaId")] Direccion direccion)
        {
            if (id != direccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DireccionExists(direccion.Id))
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
            ViewData["PersonaId"] = new SelectList(_context.Personas, "Id", "Apellido", direccion.PersonaId);
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direccion = await _context.Direccion
                .Include(d => d.Persona)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direccion == null)
            {
                return NotFound();
            }

            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direccion = await _context.Direccion.FindAsync(id);
            if (direccion != null)
            {
                _context.Direccion.Remove(direccion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DireccionExists(int id)
        {
            return _context.Direccion.Any(e => e.Id == id);
        }
    }
}
