using BL.Icontract;
using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    public class ItemImage
    {
        public class ClsItemImages : IItemImages
        {
            MyDbContext context;
            public ClsItemImages(MyDbContext ctx)
            {
                context = ctx;
            }

            public List<TbItemImage> GetByItemId(int id)
            {
                try
                {
                    var item = context.TbItemImages.Where(a => a.ItemId == id).ToList();
                    return item;
                }
                catch
                {
                    return new List<TbItemImage>();
                }
            }
        }
    }
}
