using Microsoft.EntityFrameworkCore;
using Web_DemoMVCBasics.Models;

namespace Web_DemoMVCBasics.Data
{
    public class ZenInventoryDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ZenInventoryDbContext(DbContextOptions<ZenInventoryDbContext> options): base(options)
        {
            
        }
    }
}
