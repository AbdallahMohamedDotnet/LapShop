using LapShopv2.Models;
using Microsoft.EntityFrameworkCore;
using LapShopv2.BL.Icontract;
namespace LapShopv2.BL
{
    public class ClsItem : I_DB_TBItem
    {
        MyDbContext  context;
        public ClsItem(MyDbContext context)
        {
            this.context = context;
        }
        public List<TbItem> GetAll()
        {
            try
            {

                var lstItems = context.TbItems.ToList();
                return lstItems;
            }
            catch
            {
                return new List<TbItem>();
            }
        }

        public List<VwItem> GetAllItemData(int? categoryId)
        {
            try
            {
                var lstItems = context.VwItems.Where(a => (a.CategoryId == categoryId || categoryId == null || categoryId == 0)
                // till use fuction a common facor for all items as falteration or get all items or search by name or check item is available or not 
                && a.CurrentState == 1 && !string.IsNullOrEmpty(a.ItemName)).OrderByDescending(a => a.CreatedDate).ToList();
                return lstItems;
            }
            catch
            {
                return new List<VwItem>();
            }
        }

        public List<VwItem> GetRecommendedItems(int itemId)
        {
            try
            {
                var item = GetById(itemId);
                var lstItems = context.VwItems.Where(a => a.SalesPrice > item.SalesPrice - 150
                && a.SalesPrice < item.SalesPrice + 150
                && a.CurrentState == 1).OrderByDescending(a => a.CreatedDate).ToList();
                return lstItems;
            }
            catch
            {
                return new List<VwItem>();
            }
        }

        public TbItem GetById(int id)
        // this function used on the database general 
        {
            try
            {
                // till chreck item is available or not and if item is available then return item otherwise return empty(NULL) item
                var item = context.TbItems.FirstOrDefault(a => a.ItemId == id && a.CurrentState == 1);
                return item;
            }
            catch
            {
                return new TbItem();
            }
        }

        public VwItem GetItemId(int id)
        // this function used on the data shown for user and just controle for user to check item is available or not 
        {
            try
            {
                var item = context.VwItems.FirstOrDefault(a => a.ItemId == id && a.CurrentState == 1);
                return item;
            }
            catch
            {
                return new VwItem();
            }
        }
        public bool Save(TbItem item)
        {
            try
            {
                if (item.ItemId == 0)
                // adding new Item on the database
                {
                    item.CurrentState = 1;
                    item.CreatedBy = "1";
                    item.CreatedDate = DateTime.Now;
                    context.TbItems.Add(item);
                }
                else
                // edit row on database
                {
                    item.UpdatedBy = "1";
                    item.UpdatedDate = DateTime.Now;
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var item = GetById(id);
                item.CurrentState = 0;
                // till just delete element from user show screen but till dont fail all transactions with this element 
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                // till update condition of item to delete it from user screen
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

