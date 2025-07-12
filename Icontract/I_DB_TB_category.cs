using LapShopv2.Models;

namespace LapShopv2.BL.Icontract
{
    public interface I_DB_TB_category
    {
        public List<TbCategory> GetAll();
        public TbCategory GetById(int id);
        public bool Save(TbCategory category);
        public bool Delete(int id);

    }
}
