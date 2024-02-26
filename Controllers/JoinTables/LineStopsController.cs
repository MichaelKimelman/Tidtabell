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
    public class LineStopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LineStopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LineStops
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LineStops.Include(l => l.Line).Include(l => l.Stop);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LineStops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LineStops == null)
            {
                return NotFound();
            }

            var lineStops = await _context.LineStops
                .Include(l => l.Line)
                .Include(l => l.Stop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineStops == null)
            {
                return NotFound();
            }

            return View(lineStops);
        }

        // GET: LineStops/Create
        public IActionResult Create()
        {
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Number");
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Name");
            return View();
        }

        // POST: LineStops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LineId,StopId,StopPosition,Time,Reverse")] LineStops lineStops)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineStops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Number", lineStops.LineId);
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Name", lineStops.StopId);
            return View(lineStops);
        }

        // GET: LineStops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LineStops == null)
            {
                return NotFound();
            }

            var lineStops = await _context.LineStops.FindAsync(id);
            if (lineStops == null)
            {
                return NotFound();
            }
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Number", lineStops.LineId);
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Name", lineStops.StopId);
            return View(lineStops);
        }

        // POST: LineStops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LineId,StopId,StopPosition,Time,Reverse")] LineStops lineStops)
        {
            if (id != lineStops.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineStops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineStopsExists(lineStops.Id))
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
            ViewData["LineId"] = new SelectList(_context.Line, "Id", "Number", lineStops.LineId);
            ViewData["StopId"] = new SelectList(_context.Stop, "Id", "Name", lineStops.StopId);
            return View(lineStops);
        }

        // GET: LineStops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LineStops == null)
            {
                return NotFound();
            }

            var lineStops = await _context.LineStops
                .Include(l => l.Line)
                .Include(l => l.Stop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineStops == null)
            {
                return NotFound();
            }

            return View(lineStops);
        }

        // POST: LineStops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LineStops == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LineStops'  is null.");
            }
            var lineStops = await _context.LineStops.FindAsync(id);
            if (lineStops != null)
            {
                _context.LineStops.Remove(lineStops);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineStopsExists(int id)
        {
          return (_context.LineStops?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
