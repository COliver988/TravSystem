using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;
using TravSystem.Services;

namespace TravSystem.Controllers
{
    public class TSystemsController : Controller
    {
        private readonly ITSystemRepository _repo;
        private readonly ITSubSectorRepository _subsector;
        private readonly ITBaseRepository _baseRepo;
        private readonly ITSystemGenService _systemGenService;

        public TSystemsController(ITSystemRepository repo, 
            ITSubSectorRepository subsector, 
            ITBaseRepository baseRepo,
            ITSystemGenService tSystemGenService)
        {
            _repo = repo;
            _subsector = subsector;
            _baseRepo = baseRepo;
            _systemGenService = tSystemGenService;
        }

        // GET: TSystems
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TSystems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSystem = await _repo.GetByID(id.Value);
            if (tSystem == null)
            {
                return NotFound();
            }

            ViewBag.Subsectors = await _subsector.GetAll();
            return View(tSystem);
        }

        // GET: TSystems/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Subsectors = await _subsector.GetAll();
            ViewBag.Bases = await _baseRepo.GetAll();
            return View();
        }

        // POST: TSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TSystem tSystem, List<int> selectedBaseTypeIds)
        {
            if (ModelState.IsValid)
            {
                // Add selected bases to the system
                foreach (var baseId in selectedBaseTypeIds)
                {
                    var tBase = await _baseRepo.GetByID(baseId);
                    if (tBase != null)
                        tSystem.Bases.Add(tBase);
                }
                await _repo.Add(tSystem);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Subsectors = await _subsector.GetAll();
            ViewBag.Bases = await _baseRepo.GetAll();
            return View(tSystem);
        }

        [HttpGet("GenerateSystem")]
        public async Task<IActionResult> GenerateSystem(int id)
        {
            TSystem system = await _systemGenService.GenerateSystemFromMainPlanet(id);
            return RedirectToAction(nameof(Details), new { id = system.Id });
        }


        // GET: TSystems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSystem = await _repo.GetByID(id.Value);
            if (tSystem == null)
            {
                return NotFound();
            }
            ViewBag.Subsectors = await _subsector.GetAll();
            ViewBag.Bases = await _baseRepo.GetAll();
            return View(tSystem);
        }

        // POST: TSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TSystem tSystem, List<int> selectedBaseTypeIds)
        {
            if (id != tSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    List<int> ids = await _repo.GetSystemBaseIds(tSystem.Id);
                    foreach (var baseId in selectedBaseTypeIds)
                    {
                        if (!ids.Contains(baseId))
                        {
                            var tBase = await _baseRepo.GetByID(baseId);
                            tSystem.Bases.Add(tBase);
                        }
                    }
                    await _repo.Update(tSystem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSystemExists(tSystem.Id))
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
            ViewBag.Subsectors = await _subsector.GetAll();
            return View(tSystem);
        }

        // GET: TSystems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSystem = await _repo.GetByID(id.Value);
            if (tSystem == null)
            {
                return NotFound();
            }

            return View(tSystem);
        }

        // POST: TSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSystem = await _repo.GetByID(id);
            if (tSystem != null)
            {
                await _repo.Delete(tSystem);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TSystemExists(int id)
        {
            return _repo.GetByID(id) != null;   
        }
    }
}
