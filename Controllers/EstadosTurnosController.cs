﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PeluqueriaAgendaServicio.web.Data;
using PeluqueriaAgendaServicio.web.Models;

namespace PeluqueriaAgendaServicio.web.Controllers
{
    public class EstadosTurnosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstadosTurnosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EstadosTurnoes
        public async Task<IActionResult> Index()
        {
              return _context.EstadosTurnos != null ? 
                          View(await _context.EstadosTurnos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EstadosTurnos'  is null.");
        }

        // GET: EstadosTurnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadosTurnos == null)
            {
                return NotFound();
            }

            var estadosTurno = await _context.EstadosTurnos
                .FirstOrDefaultAsync(m => m.EstadoTurnoId == id);
            if (estadosTurno == null)
            {
                return NotFound();
            }

            return View(estadosTurno);
        }

        // GET: EstadosTurnoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosTurnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstadoTurnoId,Descripcion")] EstadosTurno estadosTurno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosTurno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosTurno);
        }

        // GET: EstadosTurnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadosTurnos == null)
            {
                return NotFound();
            }

            var estadosTurno = await _context.EstadosTurnos.FindAsync(id);
            if (estadosTurno == null)
            {
                return NotFound();
            }
            return View(estadosTurno);
        }

        // POST: EstadosTurnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstadoTurnoId,Descripcion")] EstadosTurno estadosTurno)
        {
            if (id != estadosTurno.EstadoTurnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosTurno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosTurnoExists(estadosTurno.EstadoTurnoId))
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
            return View(estadosTurno);
        }

        // GET: EstadosTurnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadosTurnos == null)
            {
                return NotFound();
            }

            var estadosTurno = await _context.EstadosTurnos
                .FirstOrDefaultAsync(m => m.EstadoTurnoId == id);
            if (estadosTurno == null)
            {
                return NotFound();
            }

            return View(estadosTurno);
        }

        // POST: EstadosTurnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadosTurnos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EstadosTurnos'  is null.");
            }
            var estadosTurno = await _context.EstadosTurnos.FindAsync(id);
            if (estadosTurno != null)
            {
                _context.EstadosTurnos.Remove(estadosTurno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosTurnoExists(int id)
        {
          return (_context.EstadosTurnos?.Any(e => e.EstadoTurnoId == id)).GetValueOrDefault();
        }
    }
}
