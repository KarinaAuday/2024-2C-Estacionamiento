﻿using System;
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
    public class PersonasController : Controller
    {
        private readonly EstacionamientoContext _context;

        public PersonasController(EstacionamientoContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personas.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //Aca va el include de direccion y telefonos para que muestre el detalle de la persona con su direccion y telefonos
     
                if (id == null)
                {
                    return NotFound();
                }

                var persona = await _context.Personas.Include(clt => clt.Telefonos)
                                            .Include(clt => clt.Direccion)
                                            .FirstOrDefaultAsync(m => m.Id == id);
                //Incluyo los objetos del contexto


                if (persona == null)
                {
                    return NotFound();
                }
                var direccion = await _context.Direccion
                    .FirstOrDefaultAsync(m => m.Id == id);

                //if (direccion == null)
                //{
                //    return NotFound();
                //}


                persona.Direccion = direccion;
                //Mando al la persona con la direccion y el telefono para que se muestre en la vista
                return View(persona);


            }
        

        // GET: Personas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Email,Profesion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                //Creo direccion para la persona
                return RedirectToAction("Create", "Direcciones", new { id = persona.Id });

            }
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Email,Profesion")] Persona persona)
        {
            if (id != persona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Id))
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
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Id == id);
        }
    }
}
