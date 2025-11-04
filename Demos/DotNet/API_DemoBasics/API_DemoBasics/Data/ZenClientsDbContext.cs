using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using API_DemoBasics.Models;
using Microsoft.AspNetCore.Identity;

namespace API_DemoBasics.Data
{
    //public class ZenClientsDbContext: DbContext
    public class ZenClientsDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Customer> Customers { get; set; }

        public ZenClientsDbContext(DbContextOptions<ZenClientsDbContext> options): base(options)
        {
            
        }
    }
}
