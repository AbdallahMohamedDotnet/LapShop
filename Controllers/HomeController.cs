using LapShopv2.BL;
using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using LapShopv2.Models.IContract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace LapShopv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger , I_DB_TBItem Item , IVmHomePage VmHomePage ,I_DB_TB_category category)
        {
            this.VmHomePage = VmHomePage;
            this.Item = Item;
            _logger = logger;
        }
        I_DB_TBItem Item;
        IVmHomePage VmHomePage;
        public IActionResult Index()
        {
            VmHomePage.LstAllItem = Item.GetAllItemData(null).Take(20).ToList();
            VmHomePage.RecommededItem= Item.GetAllItemData(null).Skip(10).Take(20).ToList();
            VmHomePage.NewItem = Item.GetAllItemData(null).Skip(60).Take(20).ToList();
            VmHomePage.FreeDeliveryItem = Item.GetAllItemData(null).Skip(80).Take(20).ToList();
            return View(VmHomePage);
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
