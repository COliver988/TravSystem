using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TGovernmentsController : Controller
    {
        private readonly ITGovernmentRepository _repo;

        public TGovernmentsController(ITGovernmentRepository repo)
        {
            _repo = repo;
        }

        // GET: TGovernments
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TGovernments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tGovernment = await _repo.GetByID(id.Value);
            if (tGovernment == null)
            {
                return NotFound();
            }

            return View(tGovernment);
        }

        // GET: TGovernments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TGovernments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,HexCode")] TGovernment tGovernment)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tGovernment);
                return RedirectToAction(nameof(Index));
            }
            return View(tGovernment);
        }

        // GET: TGovernments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tGovernment = await _repo.GetByID(id.Value);
            if (tGovernment == null)
            {
                return NotFound();
            }
            return View(tGovernment);
        }

        // POST: TGovernments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,HexCode")] TGovernment tGovernment)
        {
            if (id != tGovernment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Add(tGovernment);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TGovernmentExists(tGovernment.Id))
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
            return View(tGovernment);
        }

        // GET: TGovernments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tGovernment = await _repo.GetByID(id.Value);
            if (tGovernment == null)
            {
                return NotFound();
            }

            return View(tGovernment);
        }

        // POST: TGovernments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tGovernment = await _repo.GetByID(id);
            if (tGovernment != null)
            {
                await _repo.Delete(tGovernment);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TGovernmentExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
