using LapShopv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Icontract
{
    public interface IItemImages
    {
        public List<TbItemImage> GetByItemId(int id);
    }
}
