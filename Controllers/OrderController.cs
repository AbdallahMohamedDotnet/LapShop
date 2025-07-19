//using BL.Icontract;
//using LapShopv2.BL.Icontract;
//using LapShopv2.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System.Diagnostics;
//namespace LapShopv2.Controllers
//{
//    public class OrderController : Controller
//    {
//        public OrderController(I_DB_TBItem Item , UserManager<ApplicationUser> userManager , ISalesInvoice ssalesInvoiceService)
//        {
//            this.Item = Item;
//            this.userManager = userManager;
//            this.ssalesInvoiceService = ssalesInvoiceService;
//        }
//        I_DB_TBItem Item;
//        UserManager<ApplicationUser> userManager;
//        ISalesInvoice ssalesInvoiceService;
//        public IActionResult Cart()
//        {
//            string sesstionCart = string.Empty;
//            if (HttpContext.Request.Cookies["Cart"] != null)
//                sesstionCart = HttpContext.Request.Cookies["Cart"];
//            var cart = JsonConvert.DeserializeObject<ShoppingCart>(sesstionCart);
//            return View(cart);
//        }

//        public IActionResult MyOrders()
//        {
//            return View();
//        }
//        [Authorize]
//        public async Task<IActionResult> OrderSuccess()
//        {
//            string sesstionCart = string.Empty;
//            if (HttpContext.Request.Cookies["Cart"] != null)
//                sesstionCart = HttpContext.Request.Cookies["Cart"];
//            var cart = JsonConvert.DeserializeObject<ShoppingCart>(sesstionCart);
//            await SaveOrder(cart);
//            return View();
//        }
//        public IActionResult AddToCart(int itemId)
//        {
//            ShoppingCart cart;

//            if (HttpContext.Request.Cookies["Cart"] != null)
//                cart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Request.Cookies["Cart"]);
//            else
//                cart = new ShoppingCart();

//            var item = Item.GetById(itemId);

//            var itemInList = cart.lstItems.Where(a => a.ItemId == itemId).FirstOrDefault();

//            if (itemInList != null)
//            {
//                itemInList.Qty++;
//                itemInList.Total = itemInList.Qty * itemInList.Price;
//            }
//            else
//            {
//                cart.lstItems.Add(new ShoppingCartItem
//                {
//                    ItemId = item.ItemId,
//                    ItemName = item.ItemName,
//                    Price = item.SalesPrice,
//                    Qty = 1,
//                    Total = item.SalesPrice
//                });
//            }
//            cart.Total = cart.lstItems.Sum(a => a.Total);

//            HttpContext.Response.Cookies.Append("Cart", JsonConvert.SerializeObject(cart));

//            return RedirectToAction("Cart");
//        }

//        async Task SaveOrder(ShoppingCart oShopingCart)
//        {
//            try
//            {
//                List<TbSalesInvoiceItem> lstInvoiceItems = new List<TbSalesInvoiceItem>();
//                foreach (var item in oShopingCart.lstItems)
//                {
//                    lstInvoiceItems.Add(new TbSalesInvoiceItem()
//                    {
//                        ItemId = item.ItemId,
//                        Qty = item.Qty,
//                        InvoicePrice = item.Price
//                    });
//                }

//                var user = await userManager.GetUserAsync(User);

//                TbSalesInvoice oSalesInvoice = new TbSalesInvoice()
//                {
//                    InvoiceDate = DateTime.Now,
//                    CustomerId = Guid.Parse(user.Id),
//                    DelivryDate = DateTime.Now.AddDays(5),
//                    CreatedBy = user.Id,
//                    CreatedDate = DateTime.Now
//                };

//                ssalesInvoiceService.Save(oSalesInvoice, lstInvoiceItems, true);
//            }
//            catch (Exception ex)
//            {

//            }
//        }
//    }
//}
