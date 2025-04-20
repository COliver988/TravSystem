using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TStarportsController : Controller
    {
        private readonly TravellerDBContext _context;

        public TStarportsController(TravellerDBContext context)
        {
            _context = context;
        }

        // GET: TStarports
        public async Task<IActionResult> Index()
        {
            return View(await _context.Starports.ToListAsync());
        }

        // GET: TStarports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStarport = await _context.Starports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tStarport == null)
            {
                return NotFound();
            }

            return View(tStarport);
        }

        // GET: TStarports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TStarports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,HexCode")] TStarport tStarport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tStarport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tStarport);
        }

        // GET: TStarports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStarport = await _context.Starports.FindAsync(id);
            if (tStarport == null)
            {
                return NotFound();
            }
            return View(tStarport);
        }

        // POST: TStarports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,HexCode")] TStarport tStarport)
        {
            if (id != tStarport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tStarport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TStarportExists(tStarport.Id))
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
            return View(tStarport);
        }

        // GET: TStarports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStarport = await _context.Starports
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tStarport == null)
            {
                return NotFound();
            }

            return View(tStarport);
        }

        // POST: TStarports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tStarport = await _context.Starports.FindAsync(id);
            if (tStarport != null)
            {
                _context.Starports.Remove(tStarport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TStarportExists(int id)
        {
            return _context.Starports.Any(e => e.Id == id);
        }
    }
}
