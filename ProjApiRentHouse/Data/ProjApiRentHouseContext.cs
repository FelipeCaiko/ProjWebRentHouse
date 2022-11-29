using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace ProjApiRentHouse.Data
{
    public class ProjApiRentHouseContext : DbContext
    {
        public ProjApiRentHouseContext (DbContextOptions<ProjApiRentHouseContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.RealtyRent> RealtyRent { get; set; } = default!;
    }
}
