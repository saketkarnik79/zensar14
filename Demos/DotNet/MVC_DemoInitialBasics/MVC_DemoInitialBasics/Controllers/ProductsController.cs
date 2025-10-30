using Microsoft.AspNetCore.Mvc;
using MVC_DemoInitialBasics.Models;
using System.Diagnostics;

namespace MVC_DemoInitialBasics.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet] //Action selector attribute
        public IActionResult Index()
        {
            Product p1=new Product
            {
                Id = 1,
                Name = "Laptop",
                Description = "A high-performance laptop.",
                Price = 999
            };
            ViewData.Model = p1;
            return View();
        }

        [HttpPost] //Action selector attribute
        public IActionResult Index(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                Product p1 = new Product
                {
                    Id = int.Parse(form["Id"]),
                    Name = form["Name"],
                    Description = form["Description"],
                    Price = long.Parse(form["Price"])
                };
                Debug.WriteLine($"Product Details: Id={p1.Id}, Name={p1.Name}, Description={p1.Description}, Price={p1.Price}");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Debug.WriteLine("Form data is not valid.");
                ModelState.AddModelError(string.Empty, "Please correct the errors and try again.");
                return View();
            }
        }
    }
}
