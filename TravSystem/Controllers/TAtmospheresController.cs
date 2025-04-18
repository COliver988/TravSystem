using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers;

public class TAtmospheresController : Controller
{
    private readonly ITAtmopshereRepository _repo;

    public TAtmospheresController(ITAtmopshereRepository atmopshereRepository)
    {
        _repo = atmopshereRepository;
    }

    // GET: TAtmospheres
    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAll());
    }

    // GET: TAtmospheres/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tAtmosphere = await _repo.GetByID(id.Value);
        if (tAtmosphere == null)
        {
            return NotFound();
        }

        return View(tAtmosphere);
    }

    // GET: TAtmospheres/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TAtmospheres/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,HexCode,Name,Description")] TAtmosphere tAtmosphere)
    {
        if (ModelState.IsValid)
        {
            await _repo.Add(tAtmosphere);
            return RedirectToAction(nameof(Index));
        }
        return View(tAtmosphere);
    }

    // GET: TAtmospheres/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tAtmosphere = await _repo.GetByID(id.Value);
        if (tAtmosphere == null)
        {
            return NotFound();
        }
        return View(tAtmosphere);
    }

    // POST: TAtmospheres/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,HexCode,Name,Description")] TAtmosphere tAtmosphere)
    {
        if (id != tAtmosphere.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _repo.Update(tAtmosphere);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (TAtmosphereExists(tAtmosphere.Id) == false)
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
        return View(tAtmosphere);
    }

    // GET: TAtmospheres/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tAtmosphere = await _repo.GetByID(id.Value);
        if (tAtmosphere == null)
        {
            return NotFound();
        }

        return View(tAtmosphere);
    }

    // POST: TAtmospheres/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var tAtmosphere = await _repo.GetByID(id);
        if (tAtmosphere != null)
        {
            await _repo.Delete(tAtmosphere);
        }

        return RedirectToAction(nameof(Index));
    }

    private bool TAtmosphereExists(int id)
    {
        return _repo.GetByID(id) != null;
    }
}
