using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
namespace LapShopv2.Controllers
{
    public class OrderController : Controller
    {
        public OrderController(I_DB_TBItem Item)
        {
            this.Item = Item;
        }
        I_DB_TBItem Item;
        public IActionResult Cart()
        {
            string sesstionCart = string.Empty;
            if (HttpContext.Request.Cookies.ContainsKey("Cart"))
            {
                sesstionCart = HttpContext.Request.Cookies["Cart"];
            }
            var cart = JsonConvert.DeserializeObject<shoppingCartItem>(sesstionCart);
            return View(cart);
        }
        public IActionResult AddToCard(int ItemId) {

            shoppingCartItem cart;

            if (HttpContext.Request.Cookies["Cart"] != null)
                cart = JsonConvert.DeserializeObject<shoppingCartItem>(HttpContext.Request.Cookies["Cart"]); 
            else
                cart = new shoppingCartItem();

            var item = Item.GetById(ItemId);

            var itemInList = cart.L_shoppingCartItem.Where(a => a.ItemId == ItemId).FirstOrDefault();

            if (itemInList != null)
            {
                itemInList.ItemQuantity++;
                itemInList.ItemTotalPrice = itemInList.ItemQuantity * itemInList.ItemPrice;
            }
            else
            {
                cart.L_shoppingCartItem.Add(new shoppingCartItem
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ItemPrice  = item.SalesPrice,
                    ItemQuantity = 1,
                    ItemTotalPrice = item.SalesPrice
                });
            }
            cart.ItemTotalPrice = cart.L_shoppingCartItem.Sum(a => a.ItemTotalPrice);

            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

            return RedirectToAction("Cart");
        }
    }
}
