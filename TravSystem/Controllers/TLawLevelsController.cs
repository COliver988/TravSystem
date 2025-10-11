using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TLawLevelsController : Controller
    {
        private readonly ITLawLevelRepository _repo;

        public TLawLevelsController(ITLawLevelRepository repo)
        {
            _repo = repo;
        }

        // GET: TLawLevels
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TLawLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tLawLevel = await _repo.GetByID(id.Value);
            if (tLawLevel == null)
            {
                return NotFound();
            }

            return View(tLawLevel);
        }

        // GET: TLawLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TLawLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,HexCode")] TLawLevel tLawLevel)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tLawLevel);
                return RedirectToAction(nameof(Index));
            }
            return View(tLawLevel);
        }

        // GET: TLawLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tLawLevel = await _repo.GetByID(id.Value);
            if (tLawLevel == null)
            {
                return NotFound();
            }
            return View(tLawLevel);
        }

        // POST: TLawLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,HexCode")] TLawLevel tLawLevel)
        {
            if (id != tLawLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tLawLevel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TLawLevelExists(tLawLevel.Id))
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
            return View(tLawLevel);
        }

        // GET: TLawLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tLawLevel = await _repo.GetByID(id.Value);
            if (tLawLevel == null)
            {
                return NotFound();
            }

            return View(tLawLevel);
        }

        // POST: TLawLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tLawLevel = await _repo.GetByID(id);
            if (tLawLevel != null)
            {
                await _repo.Delete(tLawLevel);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TLawLevelExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
