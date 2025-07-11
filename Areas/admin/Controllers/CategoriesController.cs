using Microsoft.AspNetCore.Mvc;
using LapShopv2.Models;
using LapShopv2.BL;
using Microsoft.AspNetCore.Http.Metadata;
using LapShopv2.Utlities;
using Domains;
using LapShopv2.BL.Icontract;
namespace LapShopv2.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        public CategoriesController(I_DB_TB_category category)
        {
            this.oClsCategories = category;
        }
        I_DB_TB_category  oClsCategories ;
        public IActionResult List()
        {
            return View(oClsCategories.GetAll());
        }
        public IActionResult Edit(int? id)
        {
                return View(oClsCategories.GetById(Convert.ToInt32(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbCategory category , List<IFormFile> Files)
        {
            //if (!ModelState.IsValid)
            //    return View("Edit", category);
            category.ImageName = await Helper.UploadImage(Files, "Categories");
            oClsCategories.Save(category);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            oClsCategories.Delete(id);
            return RedirectToAction("List");
        }
        
    }
}
