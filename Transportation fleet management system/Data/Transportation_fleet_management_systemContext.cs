using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFMS.Models;

namespace Transportation_fleet_management_system.Data
{
    public class Transportation_fleet_management_systemContext : DbContext
    {
        public Transportation_fleet_management_systemContext (DbContextOptions<Transportation_fleet_management_systemContext> options)
            : base(options)
        {
        }

        public DbSet<TFMS.Models.Vehicle> Vehicle { get; set; } = default!;
        public DbSet<TFMS.Models.Trip> Trip { get; set; } = default!;
        public DbSet<TFMS.Models.Fuel> Fuel { get; set; } = default!;
        public DbSet<TFMS.Models.Maintenance> Maintenance { get; set; } = default!;
        public DbSet<TFMS.Models.Performance> Performance { get; set; } = default!;
        public DbSet<TFMS.Models.Driver> Driver { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
       // {
            //modelBuilder.Entity<Fuel>().ToTable("Fuels"); // Explicitly map the Fuel entity to the Fuels table
        //}//
    }
}
