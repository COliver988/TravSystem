using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TCapturedAndEmptiesController : Controller
    {
        private readonly ITCapturedAndEmpty _repo;

        public TCapturedAndEmptiesController(ITCapturedAndEmpty repo)
        {
            _repo = repo;
        }

        // GET: TCapturedAndEmpties
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TCapturedAndEmpties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCapturedAndEmpty = await _repo.GetByID(id.Value);
            if (tCapturedAndEmpty == null)
            {
                return NotFound();
            }

            return View(tCapturedAndEmpty);
        }

        // GET: TCapturedAndEmpties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TCapturedAndEmpties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DieRoll,Captures,CapturedQty,EmptyOrbits,EmptyOrbitsQty")] TCapturedAndEmpty tCapturedAndEmpty)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tCapturedAndEmpty);
                return RedirectToAction(nameof(Index));
            }
            return View(tCapturedAndEmpty);
        }

        // GET: TCapturedAndEmpties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCapturedAndEmpty = await _repo.GetByID(id.Value);
            if (tCapturedAndEmpty == null)
            {
                return NotFound();
            }
            return View(tCapturedAndEmpty);
        }

        // POST: TCapturedAndEmpties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DieRoll,Captures,CapturedQty,EmptyOrbits,EmptyOrbitsQty")] TCapturedAndEmpty tCapturedAndEmpty)
        {
            if (id != tCapturedAndEmpty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tCapturedAndEmpty);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TCapturedAndEmptyExists(tCapturedAndEmpty.Id))
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
            return View(tCapturedAndEmpty);
        }

        // GET: TCapturedAndEmpties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tCapturedAndEmpty = await _repo.GetByID(id.Value);
            if (tCapturedAndEmpty == null)
            {
                return NotFound();
            }

            return View(tCapturedAndEmpty);
        }

        // POST: TCapturedAndEmpties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tCapturedAndEmpty = await _repo.GetByID(id);
            if (tCapturedAndEmpty != null)
            {
                await _repo.Delete(tCapturedAndEmpty);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TCapturedAndEmptyExists(int id)
        {
            return _repo.GetByID(id).Result != null;
        }
    }
}
