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
    public class LocatorsController : Controller
    {
        private readonly ProjWebRentHouseContext _context;

        public LocatorsController(ProjWebRentHouseContext context)
        {
            _context = context;
        }

        // GET: Locators
        public async Task<IActionResult> Index()
        {
              return View(await _context.Locator.ToListAsync());
        }

        // GET: Locators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locator == null)
            {
                return NotFound();
            }

            var locator = await _context.Locator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locator == null)
            {
                return NotFound();
            }

            return View(locator);
        }

        // GET: Locators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CPF,Telephone")] Locator locator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locator);
        }

        // GET: Locators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locator == null)
            {
                return NotFound();
            }

            var locator = await _context.Locator.FindAsync(id);
            if (locator == null)
            {
                return NotFound();
            }
            return View(locator);
        }

        // POST: Locators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CPF,Telephone")] Locator locator)
        {
            if (id != locator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocatorExists(locator.Id))
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
            return View(locator);
        }

        // GET: Locators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locator == null)
            {
                return NotFound();
            }

            var locator = await _context.Locator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locator == null)
            {
                return NotFound();
            }

            return View(locator);
        }

        // POST: Locators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locator == null)
            {
                return Problem("Entity set 'ProjWebRentHouseContext.Locator'  is null.");
            }
            var locator = await _context.Locator.FindAsync(id);
            if (locator != null)
            {
                _context.Locator.Remove(locator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatorExists(int id)
        {
          return _context.Locator.Any(e => e.Id == id);
        }
    }
}
