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
    public class PeriodoController : Controller
    {
        private readonly Contexto _context;

        public PeriodoController(Contexto context)
        {
            _context = context;
        }

        // GET: Periodo
        public async Task<IActionResult> Index()
        {
              return _context.Periodo != null ? 
                          View(await _context.Periodo.ToListAsync()) :
                          Problem("Entity set 'Contexto.Periodo'  is null.");
        }

        // GET: Periodo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Periodo == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo
                .FirstOrDefaultAsync(m => m.id == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // GET: Periodo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periodo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NomePeriodo")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(periodo);
        }

        // GET: Periodo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Periodo == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }

        // POST: Periodo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NomePeriodo")] Periodo periodo)
        {
            if (id != periodo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoExists(periodo.id))
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
            return View(periodo);
        }

        // GET: Periodo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Periodo == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo
                .FirstOrDefaultAsync(m => m.id == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // POST: Periodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Periodo == null)
            {
                return Problem("Entity set 'Contexto.Periodo'  is null.");
            }
            var periodo = await _context.Periodo.FindAsync(id);
            if (periodo != null)
            {
                _context.Periodo.Remove(periodo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodoExists(int id)
        {
          return (_context.Periodo?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
