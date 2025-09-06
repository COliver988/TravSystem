using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEfCoreApp.Data;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class StarTypesController : Controller
    {
        private readonly IStarTypeRepository _repo;

        public StarTypesController(IStarTypeRepository context)
        {
            _repo = context;
        }

        // GET: StarTypes
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: StarTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starType = await _repo.GetByID(id.Value);
            if (starType == null)
            {
                return NotFound();
            }

            return View(starType);
        }

        // GET: StarTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StarTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] StarType starType)
        {
            if (ModelState.IsValid)
            {
                await _repo.Update(starType);
                return RedirectToAction(nameof(Index));
            }
            return View(starType);
        }

        // GET: StarTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starType = await _repo.GetByID(id.Value);
            if (starType == null)
            {
                return NotFound();
            }
            return View(starType);
        }

        // POST: StarTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type")] StarType starType)
        {
            if (id != starType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(starType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StarTypeExists(starType.Id))
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
            return View(starType);
        }

        // GET: StarTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var starType = await _repo.GetByID(id.Value);
            if (starType == null)
            {
                return NotFound();
            }

            return View(starType);
        }

        // POST: StarTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var starType = await _repo.GetByID(id);
            if (starType != null)
            {
                //_repo.StarTypes.Remove(starType);
            }

            //await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StarTypeExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
