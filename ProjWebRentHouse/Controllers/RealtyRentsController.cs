using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using ProjWebRentHouse.Data;
using ProjApiRentHouse.Controllers;

namespace ProjWebRentHouse.Controllers
{
    public class RealtyRentsController : Controller
    {
        private readonly ProjWebRentHouseContext _context;

        public RealtyRentsController(ProjWebRentHouseContext context)
        {
            _context = context;
        }

        // GET: RealtyRents
        public async Task<IActionResult> Index()
        {
            return View(await _context.RealtyRent.ToListAsync());
        }

        // GET: RealtyRents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RealtyRent == null)
            {
                return NotFound();
            }

            var realtyRent = await _context.RealtyRent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realtyRent == null)
            {
                return NotFound();
            }

            return View(realtyRent);
        }

        // GET: RealtyRents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RealtyRents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] RealtyRent realtyRent)
        {
            if (ModelState.IsValid)
            {
                await new ConsumerController().PostRealtyRentAsync(realtyRent);
            }
            return View(realtyRent);
        }

        // GET: RealtyRents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RealtyRent == null)
            {
                return NotFound();
            }

            var realtyRent = await _context.RealtyRent.FindAsync(id);
            if (realtyRent == null)
            {
                return NotFound();
            }
            return View(realtyRent);
        }

        // POST: RealtyRents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] RealtyRent realtyRent)
        {
            if (id != realtyRent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realtyRent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealtyRentExists(realtyRent.Id))
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
            return View(realtyRent);
        }

        // GET: RealtyRents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RealtyRent == null)
            {
                return NotFound();
            }

            var realtyRent = await _context.RealtyRent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realtyRent == null)
            {
                return NotFound();
            }

            return View(realtyRent);
        }

        // POST: RealtyRents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RealtyRent == null)
            {
                return Problem("Entity set 'ProjWebRentHouseContext.RealtyRent'  is null.");
            }
            var realtyRent = await _context.RealtyRent.FindAsync(id);
            if (realtyRent != null)
            {
                _context.RealtyRent.Remove(realtyRent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealtyRentExists(int id)
        {
            return _context.RealtyRent.Any(e => e.Id == id);
        }
    }
}
