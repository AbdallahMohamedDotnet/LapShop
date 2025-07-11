using Domains;
using LapShopv2.BL;
using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using LapShopv2.Utlities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace LapShopv2.Areas.admin.Controllers
{
    [Area("admin")]
    public class ItemsController : Controller
    {
        public ItemsController(I_DB_TBItem item , I_DB_TB_category category , I_DB_ItemType itemType  , I_DB_Os os)
        {
            this.oClsItem = item;
            this.oClsCategories = category;
            this.oClsItemType = itemType;
            this.oClsOs = os;
        }
        MyDbContext context = new MyDbContext();
        I_DB_TBItem oClsItem ;
        I_DB_TB_category  oClsCategories ;
        I_DB_ItemType  oClsItemType ;
        I_DB_Os  oClsOs ;

        public IActionResult List()
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            var items = oClsItem.GetAllItemData(null);
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem Item, List<IFormFile> Files)
        {
            //if (!ModelState.IsValid)
            //    return View("Edit", Item);
            Item.ImageName = await Helper.UploadImage(Files, "Items");
            oClsItem.Save(Item);
            return RedirectToAction("List");
        }

        public IActionResult Search(int id)
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            var items = oClsItem.GetAllItemData(id);
            return View("List", items);
        }

        public IActionResult Delete(int itemId)
        {
            oClsItem.Delete(itemId);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int? itemId)
        {
            var item = new TbItem();
            ViewBag.lstCategories = oClsCategories.GetAll();
            ViewBag.lstItemTypes = oClsItemType.GetAll();
            ViewBag.context = new MyDbContext();
            ViewBag.lstOs = oClsOs.GetAll();
            ViewBag.lstOs = context.TbOs.ToList();
            if (itemId != null)
            {
                item = oClsItem.GetById(Convert.ToInt32(itemId));
            }
            return View(item);
        }
    }
}
