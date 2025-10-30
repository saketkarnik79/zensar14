using CS_DemoEFCoreDBFirst.Models;
using CS_DemoEFCoreDBFirst.Data;
using Microsoft.EntityFrameworkCore;

namespace CS_DemoEFCoreDBFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ZenInventoryDbContext>();
            //optionsBuilder.UseInMemoryDatabase("ZenInventory");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ZenInventoryDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
            using (var context = new ZenInventoryDbContext(optionsBuilder.Options))
            {
                // Ensure database is created
                //context.Database.EnsureCreated();
                // Add a new product
                var product = new Product { Name = "Sample Product", Description = "Sample Description", Price = 9.99M };
                context.Products.Add(product);
                context.SaveChanges();
                // Query and display products
                //var products = context.Products.ToList();
                var products = from p in context.Products.ToList()
                               where p.Price > 5.00M
                               select p;
                foreach (var p in products)
                {
                    Console.WriteLine($"Product ID: {p.Id}, Name: {p.Name}, Price: {p.Price}");
                }

                // Update a product
                product.Price = 12.99M;
                context.Products.Update(product);
                context.SaveChanges();
                Console.WriteLine($"Updated Product ID: {product.Id}, New Price: {product.Price}");

                Console.WriteLine();
                Console.WriteLine();

                // Query and display products
                products = context.Products.ToList();
                foreach (var p in products)
                {
                    Console.WriteLine($"Product ID: {p.Id}, Name: {p.Name}, Price: {p.Price}");
                }

                // Delete a product
                context.Products.Remove(product);
                context.SaveChanges();
                Console.WriteLine($"Deleted Product ID: {product.Id}");
                Console.WriteLine();
                Console.WriteLine();
                // Query and display products
                products = context.Products.ToList();
                foreach (var p in products)
                {
                    Console.WriteLine($"Product ID: {p.Id}, Name: {p.Name}, Price: {p.Price}");
                }
                // Clean up
                //context.Database.EnsureDeleted();
                Console.WriteLine("Program completed. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
