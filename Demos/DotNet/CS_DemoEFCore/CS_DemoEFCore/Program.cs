using Microsoft.EntityFrameworkCore;
using CS_DemoEFCore.Models;
using CS_DemoEFCore.Data;

namespace CS_DemoEFCore
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
                //Add 2 Categories
                //Category 1
                var category1 = new Category
                {
                    Name = "Electronics",
                };

                context.Categories.Add(category1);
                context.SaveChanges();

                //Category 2
                var category2 = new Category
                {
                    Name = "Books",
                };

                context.Categories.Add(category2);
                context.SaveChanges();

                //Display Categories
                foreach (var cat in context.Categories.Include(c => c.Products).ToList())
                {
                    Console.WriteLine($"Category ID: {cat.CategoryId}, Name: {cat.Name}, Products Count: {cat.Products.Count}");
                }

                // Ensure database is created
                //context.Database.EnsureCreated();
                // Add a new product
                var product = new Product { Name = "Sample Product", Description="Sample Description", Price = 9.99M, CategoryId= category1.CategoryId };
                context.Products.Add(product);
                context.SaveChanges();
                // Query and display products
                //var products = context.Products.ToList();
                var products= from p in context.Products.ToList()
                              where p.Price > 5.00M
                              select p;
                foreach (var p in products)
                {
                    Console.WriteLine($"Product ID: {p.Id}, Name: {p.Name}, Price: {p.Price}, Category ID: {p.CategoryId}");
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
                //Add Customer
                var customer = new Customer
                {
                    Name = "John Doe",
                    Address = "123 Main St",
                    Email = "john.doe@example.com",
                    Phone = "555-1234"
                };
                context.Customers.Add(customer);
                context.SaveChanges();

                // Display added customer

                Console.WriteLine($"Added Customer ID: {customer.Id}");
                foreach (var c in context.Customers.ToList())
                {
                    Console.WriteLine($"Customer ID: {c.Id}, Name: {c.Name}, Address: {c.Address}, Email: {c.Email}, Phone: {c.Phone}");
                }

               



                Console.WriteLine("Program completed. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
