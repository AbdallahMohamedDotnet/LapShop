using Microsoft.AspNetCore.Mvc;
using LapShopv2.Models;
using LapShopv2.BL;
using Microsoft.AspNetCore.Http.Metadata;
namespace LapShopv2.Areas.admin.Controllers
{
    [Area("admin")]
    public class CategoriesController : Controller
    {
        ClsCategories oClsCategories = new ClsCategories();
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
        public IActionResult Save(TbCategory category)
        {


            oClsCategories.Save(category);

                return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            oClsCategories.Delete(id);
            return RedirectToAction("List");
        }

        async Task<string> UploadImage(List<IFormFile> images)
        {
            foreach (var image in images)
            {
                if (image.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Uploads/categories", ImageName);
                    using (var stream = System.IO.File.Create(filepath))
                    {
                        await image.CopyToAsync(stream);
                        return ImageName;
                    }
                }
                
            }
            return "default.png"; // Return default image if no image is uploaded
        }
    }
}
