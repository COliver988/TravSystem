using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Data.Models;

namespace TravSystem.Controllers
{
    public class StellarDatasController : Controller
    {
        private readonly TravellerDBContext _context;

        public StellarDatasController(TravellerDBContext context)
        {
            _context = context;
        }

        // GET: StellarDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.StellarData.ToListAsync());
        }

        // GET: StellarDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellarData = await _context.StellarData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stellarData == null)
            {
                return NotFound();
            }

            return View(stellarData);
        }

        // GET: StellarDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StellarDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StarTypeId,StellarTypeId,Magnitude,Luminosity,Temperature,Radius,Mass")] StellarData stellarData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stellarData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stellarData);
        }

        // GET: StellarDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellarData = await _context.StellarData.FindAsync(id);
            if (stellarData == null)
            {
                return NotFound();
            }
            return View(stellarData);
        }

        // POST: StellarDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StarTypeId,StellarTypeId,Magnitude,Luminosity,Temperature,Radius,Mass")] StellarData stellarData)
        {
            if (id != stellarData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stellarData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StellarDataExists(stellarData.Id))
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
            return View(stellarData);
        }

        // GET: StellarDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellarData = await _context.StellarData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stellarData == null)
            {
                return NotFound();
            }

            return View(stellarData);
        }

        // POST: StellarDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stellarData = await _context.StellarData.FindAsync(id);
            if (stellarData != null)
            {
                _context.StellarData.Remove(stellarData);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StellarDataExists(int id)
        {
            return _context.StellarData.Any(e => e.Id == id);
        }
    }
}
