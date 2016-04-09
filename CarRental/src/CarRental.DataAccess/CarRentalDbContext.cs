using CarRental.DataAccess.Entities;
using Microsoft.Data.Entity;

namespace CarRental.DataAccess
{
    public class CarRentalDbContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");
        }
    }
}
