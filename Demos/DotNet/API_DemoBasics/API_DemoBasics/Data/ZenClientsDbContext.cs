using Microsoft.EntityFrameworkCore;
using API_DemoBasics.Models;

namespace API_DemoBasics.Data
{
    public class ZenClientsDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ZenClientsDbContext(DbContextOptions<ZenClientsDbContext> options): base(options)
        {
            
        }
    }
}
