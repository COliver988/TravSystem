using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravSystem.Data.Repositories;
using TravSystem.Models;

namespace TravSystem.Controllers
{
    public class TradeClassificationsController : Controller
    {
        private readonly ITradeClassificationRepository _repo;

        public TradeClassificationsController(ITradeClassificationRepository context)
        {
            _repo = context;
        }

        // GET: TradeClassifications
        public async Task<IActionResult> Index()
        {
            return View(await _repo.GetAll());
        }

        // GET: TradeClassifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeClassification = await _repo.GetByID(id.Value);
            if (tradeClassification == null)
            {
                return NotFound();
            }

            return View(tradeClassification);
        }

        // GET: TradeClassifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TradeClassifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abbreviation,Size,Atmo,Hydro,Population,Government,LawLevel,TechLevel")] TradeClassification tradeClassification)
        {
            if (ModelState.IsValid)
            {
                await _repo.Add(tradeClassification);
                return RedirectToAction(nameof(Index));
            }
            return View(tradeClassification);
        }

        // GET: TradeClassifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeClassification = await _repo.GetByID(id.Value);
            if (tradeClassification == null)
            {
                return NotFound();
            }
            return View(tradeClassification);
        }

        // POST: TradeClassifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abbreviation,Size,Atmo,Hydro,Population,Government,LawLevel,TechLevel")] TradeClassification tradeClassification)
        {
            if (id != tradeClassification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repo.Update(tradeClassification);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeClassificationExists(tradeClassification.Id))
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
            return View(tradeClassification);
        }

        // GET: TradeClassifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradeClassification = await _repo.GetByID(id.Value);
            if (tradeClassification == null)
            {
                return NotFound();
            }

            return View(tradeClassification);
        }

        // POST: TradeClassifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tradeClassification = await _repo.GetByID(id);
            if (tradeClassification != null)
            {
                await _repo.Delete(tradeClassification);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TradeClassificationExists(int id)
        {
            return _repo.GetByID(id) != null;
        }
    }
}
