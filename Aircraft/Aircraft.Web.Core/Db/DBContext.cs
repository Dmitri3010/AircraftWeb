using Aircraft.Web.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Aircraft.Web.Core.Db
{
    public class DBContext:DbContext
    {
        public static string ConnectionString { get; set; }
        
        public DbSet<Airports> Airports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
    }
}