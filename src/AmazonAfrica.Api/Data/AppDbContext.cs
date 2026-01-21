using Microsoft.EntityFrameworkCore;
using AmazonAfrica.Api.Models;

namespace AmazonAfrica.Api.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _schema;

        public AppDbContext(DbContextOptions<AppDbContext> options, string schema = "amazonafrica") 
            : base(options) 
        {
            _schema = schema;
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_schema);
            base.OnModelCreating(modelBuilder);
        }
    }
}
