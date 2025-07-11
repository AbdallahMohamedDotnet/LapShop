using LapShopv2.BL;
using LapShopv2.Models;
using LapShopv2.Utlities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domains;
namespace LapShopv2.Areas.admin.Controllers
{
    [Area("admin")]
    public class ItemsController : Controller
    {
        MyDbContext context = new MyDbContext();
        ClsItem oClsItem = new ClsItem(new MyDbContext());
        ClsCategories oClsCategories = new ClsCategories();
        ClsItemTypes oClsItemType = new ClsItemTypes();
        ClsOs oClsOs = new ClsOs();

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
