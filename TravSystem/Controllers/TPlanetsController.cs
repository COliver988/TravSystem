using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;
using TravSystem.Services;

namespace TravSystem.Controllers;

public class TPlanetsController : Controller
{
    private readonly ITPlanetRepository _repo;
    private readonly ITAtmopshereRepository _atmo;
    private readonly ITGovernmentRepository _government;
    private readonly ITLawLevelRepository _lawlevel;
    private readonly ITStarportRepository _starports;
    private readonly ITSubSectorRepository _subSectorRepository;
    private readonly ITPlanetGenService _planetGenService;
    private readonly ITTravelCodeRepository _travelCodeRepository;
    private readonly ITSystemRepository _systemRepository;
    private readonly IPlanetDetailsService _detailsService;
    private ITravellerWorldMapForm8 _worldMapService;

    public TPlanetsController(ITPlanetRepository repository,
        ITAtmopshereRepository atmopshereRepository,
        ITGovernmentRepository governmentRepository,
        ITLawLevelRepository lawLevelRepository,
        ITStarportRepository starportRepository,
        ITSubSectorRepository subSectorRepository,
        ITPlanetGenService tPlanetGenService,
        ITTravelCodeRepository travelCodeRepository,
        ITSystemRepository systemRepository,
        IPlanetDetailsService planetDetailsService,
        ITravellerWorldMapForm8 travellerWorldMapForm8)
    {
        _atmo = atmopshereRepository;
        _repo = repository;
        _government = governmentRepository;
        _lawlevel = lawLevelRepository;
        _starports = starportRepository;
        _subSectorRepository = subSectorRepository;
        _planetGenService = tPlanetGenService;
        _travelCodeRepository = travelCodeRepository;
        _systemRepository = systemRepository;
        _detailsService = planetDetailsService;
        _worldMapService = travellerWorldMapForm8;
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

        ViewBag.Details = await _detailsService.GetDetails(tPlanet);
        return View(tPlanet);
    }

    // GET: TPlanets/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        ViewBag.LawLevels = await _lawlevel.GetAll();
        ViewBag.Starports = await _starports.GetAll();
        ViewBag.SubSectors = await _subSectorRepository.GetAll();
        ViewBag.TravelCodes = await _travelCodeRepository.GetAll();
        ViewBag.Systems = await _systemRepository.GetAll();
        return View();
    }

    // POST: TPlanets/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,TSubSectorId,TPlanetId,Name,Orbit,TStarportID,Size,TAtmosphereID,THydrographicsID,Population,TGovernmentID,TLawLevelID,TechLevel")] TPlanet tPlanet)
    {
        if (ModelState.IsValid)
        {
            _repo.Add(tPlanet);
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        ViewBag.LawLevels = await _lawlevel.GetAll();
        ViewBag.Starports = await _starports.GetAll();
        ViewBag.SubSectors = await _subSectorRepository.GetAll();
        ViewBag.TravelCodes = await _travelCodeRepository.GetAll();
        ViewBag.Systems = await _systemRepository.GetAll();
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

        //TODO: multiple tasks and WhenAll?
        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        ViewBag.LawLevels = await _lawlevel.GetAll();
        ViewBag.Starports = await _starports.GetAll();
        ViewBag.SubSectors = await _subSectorRepository.GetAll();
        ViewBag.TravelCodes = await _travelCodeRepository.GetAll();
        ViewBag.Systems = await _systemRepository.GetAll();
        return View(tPlanet);

    }

    // from the create service
    public async Task<IActionResult> EditPlanet(TPlanet tPlanet)
    {
        if (tPlanet == null)
        {
            return NotFound();
        }
        ViewBag.Atmospheres = new SelectList(
            (await _atmo.GetAll()).Select(a => new { Id = a.Id, Name = $"{a.HexCode} {a.Name}" }),
            "Id",
            "Name"
        );

        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        ViewBag.LawLevels = await _lawlevel.GetAll();
        ViewBag.Starports = await _starports.GetAll();
        ViewBag.SubSectors = await _subSectorRepository.GetAll();
        ViewBag.TravelCodes = await _travelCodeRepository.GetAll();
        ViewBag.Systems = await _systemRepository.GetAll();
        return View("Edit", tPlanet);
    }

    // POST: TPlanets/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TPlanet tPlanet)
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
        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Governments = await _government.GetAll();
        ViewBag.Atmospheres = await _atmo.GetAll();
        ViewBag.Starports = await _starports.GetAll();
        ViewBag.SubSectors = await _subSectorRepository.GetAll();
        ViewBag.TravelCodes = await _travelCodeRepository.GetAll();
        return View(tPlanet);
    }

    public async Task<IActionResult> Generate()
    {
        TPlanet planet = await _planetGenService.GeneratePlanet();
        return RedirectToAction("EditPlanet", planet);
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

        return View(tPlanet);
    }

    public IActionResult GenerateSystem(int id)
    {
        return RedirectToRoute(new
        {
            controller = "TSystems",
            action = "GenerateSystem",
            id = id
        });
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
    public IActionResult GetWorldMap(string uwp)
    {
        // Generate the data
        var cells = _worldMapService.Generate(uwp);

        // Render to bitmap
        using var bitmap = _worldMapService.Render(cells, 500);
        using var ms = new MemoryStream();

        // Encode to PNG for the web
        bitmap.Encode(ms, SkiaSharp.SKEncodedImageFormat.Png, 100);
        var base64 = Convert.ToBase64String(ms.ToArray());

        ViewBag.MapImage = $"data:image/png;base64,{base64}";
        return PartialView("_WorldMapPartial");
    }

    private async Task<bool> TPlanetExists(int id)
    {
        return await _repo.GetByID(id) != null;
    }
}
