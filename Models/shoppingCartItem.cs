namespace LapShopv2.Models
{
    public class shoppingCartItem
    {
        public shoppingCartItem()
        {
            L_shoppingCartItem = new List<shoppingCartItem>();
        }
        public List<shoppingCartItem> L_shoppingCartItem { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemTotalPrice { get; set; }

    }
}
