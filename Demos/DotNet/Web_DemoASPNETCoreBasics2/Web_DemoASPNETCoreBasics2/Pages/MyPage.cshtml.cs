using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using Web_DemoASPNETCoreBasics2.Services;
using Web_DemoASPNETCoreBasics2.Services.Contracts;

namespace Web_DemoASPNETCoreBasics2.Pages
{
    public class MyPageModel : PageModel
    {
        private readonly IDataService _dataService;

        public MyPageModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void OnGet()
        {
            var data = _dataService.GetData();
            ViewData["Data"] = data;
        }
    }
}
