using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using ProjWebRentHouse.Data;

namespace ProjWebRentHouse.Controllers
{
    public class RealtiesController : Controller
    {
        private readonly ProjWebRentHouseContext _context;

        public RealtiesController(ProjWebRentHouseContext context)
        {
            _context = context;
        }

        // GET: Realties
        public async Task<IActionResult> Index()
        {
              return View(await _context.Realty.ToListAsync());
        }

        // GET: Realties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Realty == null)
            {
                return NotFound();
            }

            var realty = await _context.Realty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realty == null)
            {
                return NotFound();
            }

            return View(realty);
        }

        // GET: Realties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Realties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Locator,Address")] Realty realty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realty.Locator);
                _context.Add(realty.Address);
                _context.Add(realty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realty);
        }

        // GET: Realties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Realty == null)
            {
                return NotFound();
            }

            var realty = await _context.Realty.FindAsync(id);
            if (realty == null)
            {
                return NotFound();
            }
            return View(realty);
        }

        // POST: Realties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Realty realty)
        {
            if (id != realty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealtyExists(realty.Id))
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
            return View(realty);
        }

        // GET: Realties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Realty == null)
            {
                return NotFound();
            }

            var realty = await _context.Realty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realty == null)
            {
                return NotFound();
            }

            return View(realty);
        }

        // POST: Realties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Realty == null)
            {
                return Problem("Entity set 'ProjWebRentHouseContext.Realty'  is null.");
            }
            var realty = await _context.Realty.FindAsync(id);
            if (realty != null)
            {
                _context.Realty.Remove(realty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealtyExists(int id)
        {
          return _context.Realty.Any(e => e.Id == id);
        }
    }
}
