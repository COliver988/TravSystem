using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TSystemsController : Controller
    {
        private readonly ITSystemRepository _repo;
        private readonly ITSubSectorRepository _subsector;

        public TSystemsController(ITSystemRepository repo, ITSubSectorRepository subsector)
        {
            _repo = repo;
            _subsector = subsector;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: TSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubSectorId,Name")] TSystem tSystem)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tSystem);
                return RedirectToAction(nameof(Index));
            }
            return View(tSystem);
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
            return View(tSystem);
        }

        // POST: TSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubSectorId,Name")] TSystem tSystem)
        {
            if (id != tSystem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
