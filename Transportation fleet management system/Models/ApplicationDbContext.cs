using Microsoft.EntityFrameworkCore;
using TFMS.Models;

namespace TFMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Trip> Trip{ get; set; }
        public DbSet<Fuel> Fuel { get; set; }
        public DbSet<Maintenance> Maintenance{ get; set; }
        public DbSet<Performance> Performance { get; set; }
        public DbSet<Driver> Drivers { get; set; } // Add this line for the Driver class

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Vehicle)
                .WithMany()
                .HasForeignKey(t => t.VehicleId);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Driver)
                .WithMany()
                .HasForeignKey(t => t.DriverId);
        }
        public DbSet<TFMS.Models.Login> Login { get; set; } = default!;
    }
}
