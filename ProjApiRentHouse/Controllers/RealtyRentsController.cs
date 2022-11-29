using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using ProjApiRentHouse.Data;

namespace ProjApiRentHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtyRentsController : ControllerBase
    {
        private readonly ProjApiRentHouseContext _context;

        public RealtyRentsController(ProjApiRentHouseContext context)
        {
            _context = context;
        }

        // POST: api/RealtyRents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RealtyRent>> PostRealtyRent(RealtyRent realtyRent)
        {
            _context.RealtyRent.Add(realtyRent);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealtyRent", new { id = realtyRent.Id }, realtyRent);
        }
    }
}