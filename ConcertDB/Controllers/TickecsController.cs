using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConcertDB.DAL;
using ConcertDB.DAL.Entities;

namespace ConcertDB.Controllers
{
    public class TickecsController : Controller
    {
        private readonly DataBaseContext _context;

        public TickecsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Tickecs
        public async Task<IActionResult> Index()
        {
              return _context.Tickets != null ? 
                          View(await _context.Tickets.ToListAsync()) :
                          Problem("Entity set 'DataBaseContext.Tickets'  is null.");
        }

        // GET: Tickecs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var tickec = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickec == null)
            {
                return NotFound();
            }

            return View(tickec);
        }

        // GET: Tickecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketID,UseDate,IsUsed,EntranceGate,Id,CreateDate,ModifiedDate")] Tickec tickec)
        {
            if (ModelState.IsValid)
            {
                tickec.Id = Guid.NewGuid();
                tickec.CreateDate = DateTime.Now;
                _context.Add(tickec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tickec);
        }

        // GET: Tickecs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var tickec = await _context.Tickets.FindAsync(id);
            if (tickec == null)
            {
                return NotFound();
            }
            return View(tickec);
        }

        // POST: Tickecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TicketID,UseDate,IsUsed,EntranceGate,Id,CreateDate,ModifiedDate")] Tickec tickec)
        {
            if (id != tickec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tickec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TickecExists(tickec.Id))
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
            return View(tickec);
        }

        // GET: Tickecs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var tickec = await _context.Tickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tickec == null)
            {
                return NotFound();
            }

            return View(tickec);
        }

        // POST: Tickecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'DataBaseContext.Tickets'  is null.");
            }
            var tickec = await _context.Tickets.FindAsync(id);
            if (tickec != null)
            {
                _context.Tickets.Remove(tickec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TickecExists(Guid id)
        {
          return (_context.Tickets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
