using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TOrbitalDistancesController : Controller
    {
        private readonly ITOrbitDistanceRepository _repo;

        public TOrbitalDistancesController(ITOrbitDistanceRepository repo)
        {
            _repo = repo;
        }

        // GET: TOrbitalDistances
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TOrbitalDistances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrbitalDistance = await _repo.GetByID(id.Value);
            if (tOrbitalDistance == null)
            {
                return NotFound();
            }

            return View(tOrbitalDistance);
        }

        // GET: TOrbitalDistances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TOrbitalDistances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Orbit,AU,Kilometers,SolarRadii")] TOrbitalDistance tOrbitalDistance)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tOrbitalDistance);
                return RedirectToAction(nameof(Index));
            }
            return View(tOrbitalDistance);
        }

        // GET: TOrbitalDistances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrbitalDistance = await _repo.GetByID(id.Value);
            if (tOrbitalDistance == null)
            {
                return NotFound();
            }
            return View(tOrbitalDistance);
        }

        // POST: TOrbitalDistances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Orbit,AU,Kilometers,SolarRadii")] TOrbitalDistance tOrbitalDistance)
        {
            if (id != tOrbitalDistance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tOrbitalDistance);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = await TOrbitalDistanceExists(tOrbitalDistance.Id);
                    if (!exists)
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
            return View(tOrbitalDistance);
        }

        // GET: TOrbitalDistances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tOrbitalDistance = await _repo.GetByID(id.Value);
            if (tOrbitalDistance == null)
            {
                return NotFound();
            }

            return View(tOrbitalDistance);
        }

        // POST: TOrbitalDistances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tOrbitalDistance = await _repo.GetByID(id);
            if (tOrbitalDistance != null)
            {
                await _repo.Delete(tOrbitalDistance);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TOrbitalDistanceExists(int id)
        {
            return await _repo.GetByID(id) != null;
        }
    }
}
