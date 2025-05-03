using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TStarportsController : Controller
    {
        private readonly ITStarportRepository _repo;

        public TStarportsController(ITStarportRepository context)
        {
            _repo = context;
        }

        // GET: TStarports
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TStarports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStarport = await _repo.GetByID(id.Value);
            if (tStarport == null)
            {
                return NotFound();
            }

            return View(tStarport);
        }

        // GET: TStarports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TStarports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,HexCode, DieRollMin, DieRollMax")] TStarport tStarport)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tStarport);
                return RedirectToAction(nameof(Index));
            }
            return View(tStarport);
        }

        // GET: TStarports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStarport = await _repo.GetByID(id.Value);
            if (tStarport == null)
            {
                return NotFound();
            }
            return View(tStarport);
        }

        // POST: TStarports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,HexCode, DieRollMin, DieRollMax")] TStarport tStarport)
        {
            if (id != tStarport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.Update(tStarport);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TStarportExists(tStarport.Id))
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
            return View(tStarport);
        }

        // GET: TStarports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tStarport = await _repo.GetByID(id.Value);
            if (tStarport == null)
            {
                return NotFound();
            }

            return View(tStarport);
        }

        // POST: TStarports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tStarport = await _repo.GetByID(id);
            if (tStarport != null)
            {
                await _repo.Delete(tStarport);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TStarportExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
