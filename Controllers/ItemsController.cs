using BL;
using BL.Icontract;
using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using Microsoft.AspNetCore.Mvc;

namespace LapShopv2.Controllers
{
    public class ItemsController : Controller
    {

        I_DB_TBItem Item;
        IItemImages ItemImages;
        public ItemsController(I_DB_TBItem Item, IItemImages ItemImages)
        {
            this.Item = Item;
            this.ItemImages = ItemImages;
        }

        public IActionResult ItemDetails(int id)
        {
            var item = Item.GetItemId(id);

            VmItemDetails vm = new VmItemDetails();
            vm.Item = item;
            vm.lstRecommendedItems = Item.GetRecommendedItems(id).Take(20).ToList();
            vm.lstItemImages = ItemImages.GetByItemId(id);
            return View(vm);
        }

        public IActionResult ItemList()
        {
            return View();
        }
    }
}
