namespace LapShopv2.Models.IContract
{
    public interface IVmHomePage
    {
        public List<VwItem> LstAllItem { get; set; }
        public List<TbCategory> LstAllCategory { get; set; }
        public List<VwItem> RecommededItem { get; set; }
        public List<VwItem> NewItem { get; set; }
        public List<VwItem> FreeDeliveryItem { get; set; }
        public List<TBSettings> Settings { get; set; }
    }
}
