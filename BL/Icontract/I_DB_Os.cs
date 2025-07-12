using LapShopv2.Models;

namespace LapShopv2.BL.Icontract
{
    public interface I_DB_Os
    {
        public List<TbO> GetAll();
        public TbO GetById(int id);
        public bool Save(TbO Os);
        public bool Delete(int id);
    }
}
