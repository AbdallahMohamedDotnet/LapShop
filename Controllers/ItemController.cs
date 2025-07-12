using LapShopv2.BL.Icontract;
using Microsoft.AspNetCore.Mvc;

namespace LapShopv2.Controllers
{
    public class ItemController : Controller
    {
        public ItemController(I_DB_TBItem item)
        {
            Iitem = item;
        }
        I_DB_TBItem Iitem;
        public IActionResult ItemDetails(int id)
        {
            var item = Iitem.GetById(id);
            return View(item);
        }
    }
}
