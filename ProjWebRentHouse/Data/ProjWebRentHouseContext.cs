using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace ProjWebRentHouse.Data
{
    public class ProjWebRentHouseContext : DbContext
    {
        public ProjWebRentHouseContext (DbContextOptions<ProjWebRentHouseContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Client> Client { get; set; } = default!;

        public DbSet<Domain.Entities.Realty> Realty { get; set; }

        public DbSet<Domain.Entities.Address> Address { get; set; }

        public DbSet<Domain.Entities.Locator> Locator { get; set; }

        public DbSet<Domain.Entities.RealtyRent> RealtyRent { get; set; }
    }
}
