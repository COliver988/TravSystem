using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Data;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class StellarDatasController : Controller
    {
        private readonly IStellarDataRepository _repo;
        private readonly IStarTypeRepository _starTypeRepository;
        private readonly ITStellarTypeRepository _stellarTypeRepository;

        public StellarDatasController(IStellarDataRepository repo, ITStellarTypeRepository stellarTypeRepository,
            IStarTypeRepository starTypeRepository)
        {
            _repo = repo;
            _stellarTypeRepository = stellarTypeRepository;
            _starTypeRepository = starTypeRepository;
        }

        // GET: StellarDatas
        public async Task<IActionResult> Index(int page = 1, int pageSize = 25)
        {
            var all = await _repo.GetAllAsync();
            var count = all.Count;
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages == 0 ? 1 : totalPages;

            var items = all.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewData["CurrentPage"] = page;
            ViewData["TotalPages"] = totalPages;
            ViewData["PageSize"] = pageSize;

            return View(items);
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

            await LoadSupportingData();
            return View(stellarData);
        }

        // GET: StellarDatas/Create
        public async Task<IActionResult> Create()
        {
            // populate dropdowns
            await LoadSupportingData();
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
            // repopulate dropdowns when returning the view on error
            await LoadSupportingData();
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
            await LoadSupportingData();
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
            // repopulate dropdowns when returning the view on error
            await LoadSupportingData();
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

            await LoadSupportingData();
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

        private async Task LoadSupportingData()
        {
            ViewData["StarTypes"] = await _starTypeRepository.GetAll();
            ViewData["StellarTypes"] = await _stellarTypeRepository.GetAll();
        }

        private bool StellarDataExists(int id)
        {
            return _repo.GetByIdAsync(id).Result != null;
        }
    }
}
