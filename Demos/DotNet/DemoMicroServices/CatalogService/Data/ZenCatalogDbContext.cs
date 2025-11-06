using Microsoft.EntityFrameworkCore;
using CatalogService.Models;

namespace CatalogService.Data
{
    public class ZenCatalogDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ZenCatalogDbContext(DbContextOptions<ZenCatalogDbContext> options): base(options)
        {
            
        }
    }
}
