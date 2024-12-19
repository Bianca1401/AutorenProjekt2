using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutorenProjekt2.Data;
using AutorenProjekt2.Models;

namespace AutorenProjekt2.Controllers
{
    public class RezensionController : Controller
    {
        private readonly AutorenProjekt2Context _context;

        public RezensionController(AutorenProjekt2Context context)
        {
            _context = context;
        }

        // GET: Rezension
        public async Task<IActionResult> Index()
        {
            var autorenProjekt2Context = _context.Rezension.Include(r => r.Bücher);
            return View(await autorenProjekt2Context.ToListAsync());
        }


        // GET: Rezension/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezension = await _context.Rezension
                .Include(r => r.Bücher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezension == null)
            {
                return NotFound();
            }

            return View(rezension);
        }

        public async Task<IActionResult> BuchRezension(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buch mit Rezensionen laden
            var buch = await _context.Buch
                .Include(b => b.Rezensionen) // Rezensionen mitladen
                .FirstOrDefaultAsync(b => b.Id == id);

            if (buch == null)
            {
                return NotFound();
            }

            return View(buch);
        }





        // GET: Rezension/Create
        public IActionResult Create()
        {
            ViewData["BuchId"] = new SelectList(_context.Buch, "Id", "Id");
            return View();
        }

        // POST: Rezension/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BuchId,Name,Kommentar,Bewertung")] Rezension rezension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BuchId"] = new SelectList(_context.Buch, "Id", "Id", rezension.BuchId);
            return View(rezension);
        }

        // GET: Rezension/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezension = await _context.Rezension.FindAsync(id);
            if (rezension == null)
            {
                return NotFound();
            }
            ViewData["BuchId"] = new SelectList(_context.Buch, "Id", "Id", rezension.BuchId);
            return View(rezension);
        }

        // POST: Rezension/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BuchId,Name,Kommentar,Bewertung")] Rezension rezension)
        {
            if (id != rezension.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezensionExists(rezension.Id))
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
            ViewData["BuchId"] = new SelectList(_context.Buch, "Id", "Id", rezension.BuchId);
            return View(rezension);
        }

        // GET: Rezension/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezension = await _context.Rezension
                .Include(r => r.Bücher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezension == null)
            {
                return NotFound();
            }

            return View(rezension);
        }

        // POST: Rezension/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezension = await _context.Rezension.FindAsync(id);
            if (rezension != null)
            {
                _context.Rezension.Remove(rezension);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezensionExists(int id)
        {
            return _context.Rezension.Any(e => e.Id == id);
        }
    }
}
