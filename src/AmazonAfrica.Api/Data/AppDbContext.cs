using Microsoft.EntityFrameworkCore;
using AmazonAfrica.Api.Models;

namespace AmazonAfrica.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        // If you have an Orders table, uncomment and add its class
        // public DbSet<Order> Orders { get; set; }
    }
}
