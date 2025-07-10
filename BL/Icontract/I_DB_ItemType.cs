using LapShopv2.Models;

namespace LapShopv2.BL.Icontract
{
    public interface I_DB_ItemType
    {
        public List<TbItemType> GetAll();


        public TbItemType GetById(int id);


        public bool Save(TbItemType ItemTypes);

        public bool Delete(int id);
    }
}
