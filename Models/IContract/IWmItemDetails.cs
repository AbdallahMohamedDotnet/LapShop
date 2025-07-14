namespace LapShopv2.Models.IContract
{
    public interface IWmItemDetails
    {
        public VwItem Item { get; set; }
        public List<TbItemImage> lstItemImages { get; set; }
        public List<VwItem> lstRecommendedItems { get; set; }
    }
}
