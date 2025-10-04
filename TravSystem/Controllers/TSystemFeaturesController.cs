using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TSystemFeaturesController : Controller
    {
        private readonly ITSystemFeaturesRepository _repo;

        public TSystemFeaturesController(ITSystemFeaturesRepository repo)
        {
            _repo = repo;
        }

        // GET: TSystemFeatures
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TSystemFeatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSystemFeature = await _repo.GetByID(id.Value);
            if (tSystemFeature == null)
            {
                return NotFound();
            }

            return View(tSystemFeature);
        }

        // GET: TSystemFeatures/Create
        public IActionResult Create()
        {
            ViewBag.NumberOfStarsList = Enum.GetValues(typeof(TSystemFeature.NumberOfStars))
                .Cast<TSystemFeature.NumberOfStars>()
                .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() })
                .ToList();

            ViewBag.OrbitsList = Enum.GetValues(typeof(TSystemFeature.Orbits))
                .Cast<TSystemFeature.Orbits>()
                .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() })
                .ToList();

            return View();
        }

        // POST: TSystemFeatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Roll,BasicNature,PrimaryType,PrimarySize,CompanionType,CompanionSize,CompanionOrbit,MaxOrbits,GasGiantPresent,GasGiantQty,BeltPresent,BeltQty")] TSystemFeature tSystemFeature)
        {
            if (ModelState.IsValid)
            {
                // Convert CompanionOrbit to string if it's not already
                if (Enum.TryParse<TSystemFeature.Orbits>(tSystemFeature.CompanionOrbit, out var orbitEnum))
                {
                    tSystemFeature.CompanionOrbit = orbitEnum.ToString();
                }
                await _repo.Upsert(tSystemFeature);
                return RedirectToAction(nameof(Index));
            }
            return View(tSystemFeature);
        }

        // GET: TSystemFeatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSystemFeature = await _repo.GetByID(id.Value);
            if (tSystemFeature == null)
            {
                return NotFound();
            }
            ViewBag.NumberOfStarsList = Enum.GetValues(typeof(TSystemFeature.NumberOfStars))
                .Cast<TSystemFeature.NumberOfStars>()
                .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() })
                .ToList();

            ViewBag.OrbitsList = Enum.GetValues(typeof(TSystemFeature.Orbits))
                .Cast<TSystemFeature.Orbits>()
                .Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() })
                .ToList();
            return View(tSystemFeature);
        }

        // POST: TSystemFeatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Roll,BasicNature,PrimaryType,PrimarySize,CompanionType,CompanionSize,CompanionOrbit,MaxOrbits,GasGiantPresent,GasGiantQty,BeltPresent,BeltQty")] TSystemFeature tSystemFeature)
        {
            if (id != tSystemFeature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Convert CompanionOrbit to string if it's not already
                    if (Enum.TryParse<TSystemFeature.Orbits>(tSystemFeature.CompanionOrbit, out var orbitEnum))
                    {
                        tSystemFeature.CompanionOrbit = orbitEnum.ToString();
                    }
                    await _repo.Upsert(tSystemFeature);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSystemFeatureExists(tSystemFeature.Id))
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
            return View(tSystemFeature);
        }

        // GET: TSystemFeatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSystemFeature = await _repo.GetByID(id.Value);
            if (tSystemFeature == null)
            {
                return NotFound();
            }

            return View(tSystemFeature);
        }

        // POST: TSystemFeatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSystemFeature = await _repo.GetByID(id);
            if (tSystemFeature != null)
            {
                await _repo.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TSystemFeatureExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
