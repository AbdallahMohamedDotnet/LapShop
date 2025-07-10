using LapShopv2.Models;
namespace LapShopv2.BL.Icontract
{
    public interface I_DB_TBItem
    {
        public List<TbItem> GetAll();
        public List<VwItem> GetAllItemData(int? categoryId);

        public List<VwItem> GetRecommendedItems(int itemId);
        public TbItem GetById(int id);
        public VwItem GetItemId(int id);
        public bool Save(TbItem item);
        public bool Delete(int id);
    }
}
