using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TWorldDatasController : Controller
    {
        private readonly ITWorldDataRepository _repo;

        public TWorldDatasController(ITWorldDataRepository context)
        {
            _repo = context;
        }

        // GET: TWorldDatas
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TWorldDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tWorldData = await _repo.GetByID(id.Value);
            if (tWorldData == null)
            {
                return NotFound();
            }

            return View(tWorldData);
        }

        // GET: TWorldDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TWorldDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WorldSize,Volume,Mass,SurfaceArea,SurfaceGravity,EscapeVelocity")] TWorldData tWorldData)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tWorldData);
                return RedirectToAction(nameof(Index));
            }
            return View(tWorldData);
        }

        // GET: TWorldDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tWorldData = await _repo.GetByID(id.Value);
            if (tWorldData == null)
            {
                return NotFound();
            }
            return View(tWorldData);
        }

        // POST: TWorldDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WorldSize,Volume,Mass,SurfaceArea,SurfaceGravity,EscapeVelocity")] TWorldData tWorldData)
        {
            if (id != tWorldData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tWorldData);
                }
                catch (DbUpdateConcurrencyException)
                {
                    bool exists = await TWorldDataExists(tWorldData.Id);
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
            return View(tWorldData);
        }

        // GET: TWorldDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tWorldData = await _repo.GetByID(id.Value);
            if (tWorldData == null)
            {
                return NotFound();
            }

            return View(tWorldData);
        }

        // POST: TWorldDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tWorldData = await _repo.GetByID(id);
            if (tWorldData != null)
            {
                await _repo.Delete(tWorldData);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TWorldDataExists(int id)
        {
            return await _repo.GetByID(id) != null;
        }
    }
}
