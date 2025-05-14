using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers;

public class TTravelCodesController : Controller
{
    private readonly ITTravelCodeRepository _repo;

    public TTravelCodesController(ITTravelCodeRepository repo)
    {
        _repo = repo;
    }

    // GET: TTravelCodes
    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAll());
    }

    // GET: TTravelCodes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tTravelCode = await _repo.GetByID(id.Value);
        if (tTravelCode == null)
        {
            return NotFound();
        }

        return View(tTravelCode);
    }

    // GET: TTravelCodes/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TTravelCodes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Code")] TTravelCode tTravelCode)
    {
        if (ModelState.IsValid)
        {
            await _repo.Add(tTravelCode);
            return RedirectToAction(nameof(Index));
        }
        return View(tTravelCode);
    }

    // GET: TTravelCodes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tTravelCode = await _repo.GetByID(id.Value);
        if (tTravelCode == null)
        {
            return NotFound();
        }
        return View(tTravelCode);
    }

    // POST: TTravelCodes/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Code")] TTravelCode tTravelCode)
    {
        if (id != tTravelCode.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _repo.Update(tTravelCode);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TTravelCodeExists(tTravelCode.Id))
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
        return View(tTravelCode);
    }

    // GET: TTravelCodes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tTravelCode = await _repo.GetByID(id.Value);
        if (tTravelCode == null)
        {
            return NotFound();
        }

        return View(tTravelCode);
    }

    // POST: TTravelCodes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var tTravelCode = await _repo.GetByID(id);
        if (tTravelCode != null)
        {
            await _repo.Delete(tTravelCode);
        }
        return RedirectToAction(nameof(Index));
    }

    private bool TTravelCodeExists(int id)
    {
        return _repo.GetByID(id) != null;
    }
}
