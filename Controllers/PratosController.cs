using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCardapio.Models;

namespace ProjetoCardapio.Controllers
{
    public class PratosController : Controller
    {
        private readonly Contexto _context;

        public PratosController(Contexto context)
        {
            _context = context;
        }

        // GET: Pratos
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Pratos.Include(p => p.Dias).Include(p => p.Periodo);
            return View(await contexto.ToListAsync());
        }

        // GET: Pratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pratos == null)
            {
                return NotFound();
            }

            var pratos = await _context.Pratos
                .Include(p => p.Dias)
                .Include(p => p.Periodo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pratos == null)
            {
                return NotFound();
            }

            return View(pratos);
        }

        // GET: Pratos/Create
        public IActionResult Create()
        {
            ViewData["DiasId"] = new SelectList(_context.Dias, "DiasId", "DiasId");
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "id", "id");
            return View();
        }

        // POST: Pratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PeriodoId,DiasId,PratoNome,LinkImagem")] Pratos pratos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pratos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiasId"] = new SelectList(_context.Dias, "DiasId", "DiasId", pratos.DiasId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "id", "id", pratos.PeriodoId);
            return View(pratos);
        }

        // GET: Pratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pratos == null)
            {
                return NotFound();
            }

            var pratos = await _context.Pratos.FindAsync(id);
            if (pratos == null)
            {
                return NotFound();
            }
            ViewData["DiasId"] = new SelectList(_context.Dias, "DiasId", "DiasId", pratos.DiasId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "id", "id", pratos.PeriodoId);
            return View(pratos);
        }

        // POST: Pratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PeriodoId,DiasId,PratoNome,LinkImagem")] Pratos pratos)
        {
            if (id != pratos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pratos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PratosExists(pratos.Id))
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
            ViewData["DiasId"] = new SelectList(_context.Dias, "DiasId", "DiasId", pratos.DiasId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "id", "id", pratos.PeriodoId);
            return View(pratos);
        }

        // GET: Pratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pratos == null)
            {
                return NotFound();
            }

            var pratos = await _context.Pratos
                .Include(p => p.Dias)
                .Include(p => p.Periodo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pratos == null)
            {
                return NotFound();
            }

            return View(pratos);
        }

        // POST: Pratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pratos == null)
            {
                return Problem("Entity set 'Contexto.Pratos'  is null.");
            }
            var pratos = await _context.Pratos.FindAsync(id);
            if (pratos != null)
            {
                _context.Pratos.Remove(pratos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PratosExists(int id)
        {
          return (_context.Pratos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
