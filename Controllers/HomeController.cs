using System.Diagnostics;
using LapShopv2.Models;
using Microsoft.AspNetCore.Mvc;
using LapShopv2.BL;
using LapShopv2.BL.Icontract;
namespace LapShopv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            I_DB_TBItem item = new ClsItem(new MyDbContext());
            return View(item.GetAllItemData(null));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
