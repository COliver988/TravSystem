using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers;

public class TPlanetsController : Controller
{
    private readonly ITPlanetRepository _repo;
    private readonly ITAtmopshereRepository _atmo;
    private readonly ITGovernmentRepository _government;

    public TPlanetsController(ITPlanetRepository repository, ITAtmopshereRepository atmopshereRepository, ITGovernmentRepository governmentRepository)
    {
        _atmo = atmopshereRepository;
        _repo = repository;
        _government = governmentRepository;
    }

    // GET: TPlanets
    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAll());
    }

    // GET: TPlanets/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tPlanet = await _repo.GetByID(id.Value);
        if (tPlanet == null)
        {
            return NotFound();
        }

        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        return View(tPlanet);
    }

    // GET: TPlanets/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        return View();
    }

    // POST: TPlanets/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,SubSectorId,PlanetId,Orbit,StarportID,Size,AtmosphereID,HydrographicsID,Population,GovernmentID,LawLevelID,TechLevelID")] TPlanet tPlanet)
    {
        if (ModelState.IsValid)
        {
            _repo.Add(tPlanet);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        return View(tPlanet);
    }

    // GET: TPlanets/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tPlanet = await _repo.GetByID(id.Value);
        if (tPlanet == null)
        {
            return NotFound();
        }
        ViewBag.Atmospheres = new SelectList(
            (await _atmo.GetAll()).Select(a => new { Id = a.Id, Name = $"{a.HexCode} {a.Name}" }),
            "Id",
            "Name"
        );

        ViewBag.Governments = await _government.GetAll();
        return View(tPlanet);

    }
    // POST: TPlanets/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,TSubSectorId,TPlanetId,Orbit,TStarportId,Size,TAtmosphereId,THydrographicsId,Population,TGovernmentId,TLawLevelID,TechLevel")] TPlanet tPlanet)
    {
        if (id != tPlanet.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _repo.Update(tPlanet);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await TPlanetExists(tPlanet.Id) == false)
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
        ViewBag.Governments = await _government.GetAll();
        ViewBag.Atmospheres = await _atmo.GetAll();
        return View(tPlanet);
    }

    // GET: TPlanets/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tPlanet = await _repo.GetByID(id.Value);
        if (tPlanet == null)
        {
            return NotFound();
        }

        ViewBag.Atmospheres = await _atmo.GetAll();
        return View(tPlanet);
    }

    // POST: TPlanets/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var tPlanet = await _repo.GetByID(id);
        if (tPlanet != null)
            await _repo.Delete(tPlanet);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> TPlanetExists(int id)
    {
        return await _repo.GetByID(id) != null;   
    }
}
