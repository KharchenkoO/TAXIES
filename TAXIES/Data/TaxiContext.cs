using TAXIES.Models;
using Microsoft.EntityFrameworkCore;

namespace TAXIES.Data
{
    public class TaxiContext : DbContext
    {
        public TaxiContext(DbContextOptions<TaxiContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Car");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}