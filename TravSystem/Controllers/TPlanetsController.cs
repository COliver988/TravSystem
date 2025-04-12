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
    public class TPlanetsController : Controller
    {
        private readonly TravellerDBContext _context;

        public TPlanetsController(TravellerDBContext context)
        {
            _context = context;
        }

        // GET: TPlanets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planets.ToListAsync());
        }

        // GET: TPlanets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPlanet = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tPlanet == null)
            {
                return NotFound();
            }

            return View(tPlanet);
        }

        // GET: TPlanets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TPlanets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubSectorId,PlanetId,Orbit,StarportID,Size,AtmosphereID,HydrographicsID,Population,GovernmentID,LawLevelID,TechLevelID")] TPlanet tPlanet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tPlanet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tPlanet);
        }

        // GET: TPlanets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPlanet = await _context.Planets.FindAsync(id);
            if (tPlanet == null)
            {
                return NotFound();
            }
            return View(tPlanet);
        }

        // POST: TPlanets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubSectorId,PlanetId,Orbit,StarportID,Size,AtmosphereID,HydrographicsID,Population,GovernmentID,LawLevelID,TechLevelID")] TPlanet tPlanet)
        {
            if (id != tPlanet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tPlanet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TPlanetExists(tPlanet.Id))
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
            return View(tPlanet);
        }

        // GET: TPlanets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tPlanet = await _context.Planets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tPlanet == null)
            {
                return NotFound();
            }

            return View(tPlanet);
        }

        // POST: TPlanets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tPlanet = await _context.Planets.FindAsync(id);
            if (tPlanet != null)
            {
                _context.Planets.Remove(tPlanet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TPlanetExists(int id)
        {
            return _context.Planets.Any(e => e.Id == id);
        }
    }
}
