using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TSettingsController : Controller
    {
        private readonly ITSettingsRepository _repo;

        public TSettingsController(ITSettingsRepository repo)
        {
            _repo = repo;
        }

        // GET: TSettings
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSettings = await _repo.GetByID(id.Value);
            if (tSettings == null)
            {
                return NotFound();
            }

            return View(tSettings);
        }

        // GET: TSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TSettings tSettings)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tSettings);
                return RedirectToAction(nameof(Index));
            }
            return View(tSettings);
        }

        // GET: TSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSettings = await _repo.GetByID(id.Value);
            if (tSettings == null)
            {
                return NotFound();
            }
            return View(tSettings);
        }

        // POST: TSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TSettings tSettings)
        {
            if (id != tSettings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tSettings);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TSettingsExists(tSettings.Id))
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
            return View(tSettings);
        }

        // GET: TSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tSettings = await _repo.GetByID(id.Value);
            if (tSettings == null)
            {
                return NotFound();
            }

            return View(tSettings);
        }

        // POST: TSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tSettings = await _repo.GetByID(id);
            if (tSettings != null)
            {
                await _repo.Delete(tSettings);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TSettingsExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
