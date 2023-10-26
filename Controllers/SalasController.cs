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
    public class SalasController : Controller
    {
        private readonly Contexto _context;

        public SalasController(Contexto context)
        {
            _context = context;
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {
              return _context.Salas != null ? 
                          View(await _context.Salas.ToListAsync()) :
                          Problem("Entity set 'Contexto.Salas'  is null.");
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var salas = await _context.Salas
                .FirstOrDefaultAsync(m => m.id == id);
            if (salas == null)
            {
                return NotFound();
            }

            return View(salas);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NomeSalas")] Salas salas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salas);
        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var salas = await _context.Salas.FindAsync(id);
            if (salas == null)
            {
                return NotFound();
            }
            return View(salas);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NomeSalas")] Salas salas)
        {
            if (id != salas.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalasExists(salas.id))
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
            return View(salas);
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var salas = await _context.Salas
                .FirstOrDefaultAsync(m => m.id == id);
            if (salas == null)
            {
                return NotFound();
            }

            return View(salas);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salas == null)
            {
                return Problem("Entity set 'Contexto.Salas'  is null.");
            }
            var salas = await _context.Salas.FindAsync(id);
            if (salas != null)
            {
                _context.Salas.Remove(salas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalasExists(int id)
        {
          return (_context.Salas?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
