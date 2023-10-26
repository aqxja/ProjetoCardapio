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
    public class PresencasController : Controller
    {
        private readonly Contexto _context;

        public PresencasController(Contexto context)
        {
            _context = context;
        }

        // GET: Presencas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Presencas.Include(p => p.Salas);
            return View(await contexto.ToListAsync());
        }

        // GET: Presencas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Presencas == null)
            {
                return NotFound();
            }

            var presencas = await _context.Presencas
                .Include(p => p.Salas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presencas == null)
            {
                return NotFound();
            }

            return View(presencas);
        }

        // GET: Presencas/Create
        public IActionResult Create()
        {
            ViewData["SalasId"] = new SelectList(_context.Salas, "id", "id");
            return View();
        }

        // POST: Presencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalasId,QuantidadeAlunos")] Presencas presencas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presencas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalasId"] = new SelectList(_context.Salas, "id", "id", presencas.SalasId);
            return View(presencas);
        }

        // GET: Presencas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Presencas == null)
            {
                return NotFound();
            }

            var presencas = await _context.Presencas.FindAsync(id);
            if (presencas == null)
            {
                return NotFound();
            }
            ViewData["SalasId"] = new SelectList(_context.Salas, "id", "id", presencas.SalasId);
            return View(presencas);
        }

        // POST: Presencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalasId,QuantidadeAlunos")] Presencas presencas)
        {
            if (id != presencas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presencas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresencasExists(presencas.Id))
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
            ViewData["SalasId"] = new SelectList(_context.Salas, "id", "id", presencas.SalasId);
            return View(presencas);
        }

        // GET: Presencas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Presencas == null)
            {
                return NotFound();
            }

            var presencas = await _context.Presencas
                .Include(p => p.Salas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presencas == null)
            {
                return NotFound();
            }

            return View(presencas);
        }

        // POST: Presencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Presencas == null)
            {
                return Problem("Entity set 'Contexto.Presencas'  is null.");
            }
            var presencas = await _context.Presencas.FindAsync(id);
            if (presencas != null)
            {
                _context.Presencas.Remove(presencas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresencasExists(int id)
        {
          return (_context.Presencas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
