using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CS_DemoEFCore.Data
{
    public class ZenInventoryDbContextFactory: IDesignTimeDbContextFactory<ZenInventoryDbContext>
    {
        public ZenInventoryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ZenInventoryDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ZenInventoryDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            return new ZenInventoryDbContext(optionsBuilder.Options);
        }
    }
}
