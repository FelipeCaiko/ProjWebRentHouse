using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjApiRentHouse.Controllers;
using ProjWebRentHouse.Data;

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
            var lst = await _context.RealtyRent.Include(c => c.Client).Include(r => r.Realty).ToListAsync();
            return View(lst);
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
            var realtyRent = new RealtyRent();

            var clients = _context.Client.ToList();
            var realties = _context.Realty.ToList();

            realtyRent.Clients = new List<SelectListItem>();
            realtyRent.Realties = new List<SelectListItem>();

            foreach (var cli in clients)
            {
                realtyRent.Clients.Add(new SelectListItem { Text = cli.Name, Value = cli.Id.ToString() });
            }
            foreach (var rea in realties)
            {
                realtyRent.Realties.Add(new SelectListItem { Text = rea.Description, Value = rea.Id.ToString() });
            }
            return View(realtyRent);
        }

        // POST: RealtyRents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] RealtyRent realtyRent)
        {
            int _clientId = int.Parse(Request.Form["Client"].ToString());
            var client = _context.Client.FirstOrDefault(m => m.Id == _clientId);
            realtyRent.Client = client;

            int _realtyId = int.Parse(Request.Form["Realty"].ToString());
            var realty = _context.Realty.FirstOrDefault(m => m.Id == _realtyId);
            realtyRent.Realty = realty;

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