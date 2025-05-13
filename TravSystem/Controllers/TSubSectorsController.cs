using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TSubSectorsController : Controller
    {
        private readonly ITSubSectorRepository _repo;

        public TSubSectorsController(ITSubSectorRepository repo)
        {
            _repo = repo;
        }

        // GET: TSubSectors
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TSubSectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSubSector = await _repo.GetByID(id.Value);
            if (tSubSector == null)
            {
                return NotFound();
            }

            return View(tSubSector);
        }

        // GET: TSubSectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TSubSectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TSubSector tSubSector)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tSubSector);
                return RedirectToAction(nameof(Index));
            }
            return View(tSubSector);
        }

        // GET: TSubSectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSubSector = await _repo.GetByID(id.Value);
            if (tSubSector == null)
            {
                return NotFound();
            }
            return View(tSubSector);
        }

        // POST: TSubSectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TSubSector tSubSector)
        {
            if (id != tSubSector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tSubSector);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSubSectorExists(tSubSector.Id))
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
            return View(tSubSector);
        }

        // GET: TSubSectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSubSector = await _repo.GetByID(id.Value);
            if (tSubSector == null)
            {
                return NotFound();
            }

            return View(tSubSector);
        }

        // POST: TSubSectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSubSector = await _repo.GetByID(id);
            if (tSubSector != null)
            {
                await _repo.Delete(tSubSector);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TSubSectorExists(int id)
        {
            return _repo.GetByID(id) == null;
        }
    }
}
