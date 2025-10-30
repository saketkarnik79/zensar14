using Microsoft.AspNetCore.Mvc;

namespace MVC_DemoInitialBasics.Controllers
{
    public class HomeController: Controller
    {
        //    public string Index()
        //    {
        //        return "Hello from HomeController.Index()";
        //    }

        //public string Index()
        //{
        //    return "<h1 style='color:green;'>Hello from HomeController.Index()</h1>"; //Outputs <h1 style='color:green;'>Hello from HomeController.Index()</h1> and not html content
        //}

        //public ContentResult Index()
        //{
        //    //return Content("<h1 style='color:green;'>Hello from HomeController.Index()</h1>"); //Outputs <h1 style='color:green;'>Hello from HomeController.Index()</h1> and not html content
        //    return Content("<h1 style='color:green;'>Hello from HomeController.Index()</h1>", "text/html");//Outputs html content
        //}

        //public IActionResult Index()
        //{
        //    //return Content("<h1 style='color:green;'>Hello from HomeController.Index()</h1>"); //Outputs <h1 style='color:green;'>Hello from HomeController.Index()</h1> and not html content
        //    return Content("<h1 style='color:green;'>Hello from HomeController.Index()</h1>", "text/html");//Outputs html content
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            ViewData.Add("Data1", "Hello from HomeController.Index2() dynamically added using ViewData.");
            ViewBag.Data2 = "Hello from HomeController.Index2() dynamically added using ViewBag.";
            return View();
        }
    }
}
