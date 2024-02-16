using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tidtabell.Data;
using Tidtabell.Models.Join_Tables;

namespace Tidtabell.Controllers.JoinTables
{
    public class StopTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StopTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StopTimes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StopTimes.Include(s => s.Stop).Include(s => s.Time);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StopTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StopTimes == null)
            {
                return NotFound();
            }

            var stopTimes = await _context.StopTimes
                .Include(s => s.Stop)
                .Include(s => s.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stopTimes == null)
            {
                return NotFound();
            }

            return View(stopTimes);
        }

        // GET: StopTimes/Create
        public IActionResult Create()
        {
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Id");
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id");
            return View();
        }

        // POST: StopTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StopId,TimeId")] StopTimes stopTimes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stopTimes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Id", stopTimes.StopId);
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id", stopTimes.TimeId);
            return View(stopTimes);
        }

        // GET: StopTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StopTimes == null)
            {
                return NotFound();
            }

            var stopTimes = await _context.StopTimes.FindAsync(id);
            if (stopTimes == null)
            {
                return NotFound();
            }
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Id", stopTimes.StopId);
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id", stopTimes.TimeId);
            return View(stopTimes);
        }

        // POST: StopTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StopId,TimeId")] StopTimes stopTimes)
        {
            if (id != stopTimes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stopTimes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StopTimesExists(stopTimes.Id))
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
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Id", stopTimes.StopId);
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id", stopTimes.TimeId);
            return View(stopTimes);
        }

        // GET: StopTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StopTimes == null)
            {
                return NotFound();
            }

            var stopTimes = await _context.StopTimes
                .Include(s => s.Stop)
                .Include(s => s.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stopTimes == null)
            {
                return NotFound();
            }

            return View(stopTimes);
        }

        // POST: StopTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StopTimes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StopTimes'  is null.");
            }
            var stopTimes = await _context.StopTimes.FindAsync(id);
            if (stopTimes != null)
            {
                _context.StopTimes.Remove(stopTimes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StopTimesExists(int id)
        {
          return (_context.StopTimes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
