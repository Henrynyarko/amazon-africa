using Microsoft.EntityFrameworkCore;
using AmazonAfrica.Api.Models;

namespace AmazonAfrica.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
