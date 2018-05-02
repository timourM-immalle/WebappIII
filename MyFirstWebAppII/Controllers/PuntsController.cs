using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstWebAppII.Models;

namespace MyFirstWebAppII.Controllers
{
    public class PuntsController : Controller
    {
        private readonly MyFirstWebAppIIContext _context;

        public PuntsController(MyFirstWebAppIIContext context)
        {
            _context = context;
        }

        // GET: Punts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Punt.ToListAsync());
        }

        // GET: Punts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punt = await _context.Punt
                .SingleOrDefaultAsync(m => m.Id == id);
            if (punt == null)
            {
                return NotFound();
            }

            return View(punt);
        }

        // GET: Punts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Punts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Leerling,Klas,Min,Max")] Punt punt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(punt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(punt);
        }

        // GET: Punts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punt = await _context.Punt.SingleOrDefaultAsync(m => m.Id == id);
            if (punt == null)
            {
                return NotFound();
            }
            return View(punt);
        }

        // POST: Punts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Leerling,Klas,Min,Max")] Punt punt)
        {
            if (id != punt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(punt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuntExists(punt.Id))
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
            return View(punt);
        }

        // GET: Punts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var punt = await _context.Punt
                .SingleOrDefaultAsync(m => m.Id == id);
            if (punt == null)
            {
                return NotFound();
            }

            return View(punt);
        }

        // POST: Punts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var punt = await _context.Punt.SingleOrDefaultAsync(m => m.Id == id);
            _context.Punt.Remove(punt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuntExists(int id)
        {
            return _context.Punt.Any(e => e.Id == id);
        }
    }
}
