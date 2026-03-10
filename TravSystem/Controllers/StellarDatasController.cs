using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Data;
using TravSystem.Data.Models;

namespace TravSystem.Controllers
{
    public class StellarDatasController : Controller
    {
        private readonly IStellarDataRepository _repo;

        public StellarDatasController(IStellarDataRepository repo)
        {
            _repo = repo;
        }

        // GET: StellarDatas
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAllAsync());
        }

        // GET: StellarDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellarData = await _repo.GetByIdAsync(id.Value);
            if (stellarData == null)
            {
                return NotFound();
            }

            return View(stellarData);
        }

        // GET: StellarDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StellarDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StarTypeId,StellarTypeId,Magnitude,Luminosity,Temperature,Radius,Mass")] StellarData stellarData)
        {
            if (ModelState.IsValid)
            {
                await _repo.AddAsync(stellarData);
                return RedirectToAction(nameof(Index));
            }
            return View(stellarData);
        }

        // GET: StellarDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellarData = await _repo.GetByIdAsync(id.Value);
            if (stellarData == null)
            {
                return NotFound();
            }
            return View(stellarData);
        }

        // POST: StellarDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StarTypeId,StellarTypeId,Magnitude,Luminosity,Temperature,Radius,Mass")] StellarData stellarData)
        {
            if (id != stellarData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.UpdateAsync(stellarData);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StellarDataExists(stellarData.Id))
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
            return View(stellarData);
        }

        // GET: StellarDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stellarData = await _repo.GetByIdAsync(id.Value);
            if (stellarData == null)
            {
                return NotFound();
            }

            return View(stellarData);
        }

        // POST: StellarDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stellarData = await _repo.GetByIdAsync(id);
            if (stellarData != null)
            {
                await _repo.DeleteAsync(stellarData);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StellarDataExists(int id)
        {
            return _repo.GetByIdAsync(id).Result != null;
        }
    }
}
