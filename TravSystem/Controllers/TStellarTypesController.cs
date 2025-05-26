using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TStellarTypesController : Controller
    {
        private readonly ITStellarTypeRepository _repo;

        public TStellarTypesController(ITStellarTypeRepository repo)
        {
            _repo = repo;
        }

        // GET: TStellarTypes
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TStellarTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStellarTypes = await _repo.GetByID(id.Value);
            if (tStellarTypes == null)
            {
                return NotFound();
            }

            return View(tStellarTypes);
        }

        // GET: TStellarTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TStellarTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Size,CompanionType,CompanionSize,CompanionOrbit")] TStellarTypes tStellarTypes)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tStellarTypes);
                return RedirectToAction(nameof(Index));
            }
            return View(tStellarTypes);
        }

        // GET: TStellarTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStellarTypes = await _repo.GetByID(id.Value);
            if (tStellarTypes == null)
            {
                return NotFound();
            }
            return View(tStellarTypes);
        }

        // POST: TStellarTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Size,CompanionType,CompanionSize,CompanionOrbit")] TStellarTypes tStellarTypes)
        {
            if (id != tStellarTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tStellarTypes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TStellarTypesExists(tStellarTypes.Id))
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
            return View(tStellarTypes);
        }

        // GET: TStellarTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStellarTypes = await _repo.GetByID(id.Value);
            if (tStellarTypes == null)
            {
                return NotFound();
            }

            return View(tStellarTypes);
        }

        // POST: TStellarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tStellarTypes = await _repo.GetByID(id);
            if (tStellarTypes != null)
            {
                await _repo.Delete(tStellarTypes);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TStellarTypesExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
