using Microsoft.EntityFrameworkCore;
using ASPNETCore_Sync_Async_EF.Models;

namespace ASPNETCore_Sync_Async_EF.Repository
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }
    }
}