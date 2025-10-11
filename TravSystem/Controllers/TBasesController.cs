using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TBasesController : Controller
    {
        private readonly ITBaseRepository _repo;

        public TBasesController(ITBaseRepository repo)
        {
            _repo = repo;
        }

        // GET: TBases
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TBases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBase = await _repo.GetByID(id.Value);
            if (tBase == null)
            {
                return NotFound();
            }

            return View(tBase);
        }

        // GET: TBases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,HexCode")] TBase tBase)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tBase);
                return RedirectToAction(nameof(Index));
            }
            return View(tBase);
        }

        // GET: TBases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBase = await _repo.GetByID(id.Value);
            if (tBase == null)
            {
                return NotFound();
            }
            return View(tBase);
        }

        // POST: TBases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,HexCode")] TBase tBase)
        {
            if (id != tBase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tBase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBaseExists(tBase.Id))
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
            return View(tBase);
        }

        // GET: TBases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBase = await _repo.GetByID(id.Value);
            if (tBase == null)
            {
                return NotFound();
            }

            return View(tBase);
        }

        // POST: TBases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBase = await _repo.GetByID(id);
            if (tBase != null)
            {
                await _repo.Delete(tBase);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TBaseExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
