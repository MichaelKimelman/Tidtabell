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
    public class LineTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LineTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LineTimes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LineTimes.Include(l => l.Line).Include(l => l.Time);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LineTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LineTimes == null)
            {
                return NotFound();
            }

            var lineTimes = await _context.LineTimes
                .Include(l => l.Line)
                .Include(l => l.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineTimes == null)
            {
                return NotFound();
            }

            return View(lineTimes);
        }

        // GET: LineTimes/Create
        public IActionResult Create()
        {
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Id");
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id");
            return View();
        }

        // POST: LineTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LineId,TimeId")] LineTimes lineTimes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineTimes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Id", lineTimes.LineId);
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id", lineTimes.TimeId);
            return View(lineTimes);
        }

        // GET: LineTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LineTimes == null)
            {
                return NotFound();
            }

            var lineTimes = await _context.LineTimes.FindAsync(id);
            if (lineTimes == null)
            {
                return NotFound();
            }
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Id", lineTimes.LineId);
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id", lineTimes.TimeId);
            return View(lineTimes);
        }

        // POST: LineTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LineId,TimeId")] LineTimes lineTimes)
        {
            if (id != lineTimes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineTimes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineTimesExists(lineTimes.Id))
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
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Id", lineTimes.LineId);
            ViewData["TimeId"] = new SelectList(_context.Time, "Id", "Id", lineTimes.TimeId);
            return View(lineTimes);
        }

        // GET: LineTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LineTimes == null)
            {
                return NotFound();
            }

            var lineTimes = await _context.LineTimes
                .Include(l => l.Line)
                .Include(l => l.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineTimes == null)
            {
                return NotFound();
            }

            return View(lineTimes);
        }

        // POST: LineTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LineTimes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LineTimes'  is null.");
            }
            var lineTimes = await _context.LineTimes.FindAsync(id);
            if (lineTimes != null)
            {
                _context.LineTimes.Remove(lineTimes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineTimesExists(int id)
        {
          return (_context.LineTimes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
