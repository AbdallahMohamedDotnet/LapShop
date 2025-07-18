using BL.Icontract;
using LapShopv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public class ClsSettings : ISettings
    {
        MyDbContext context;
        public ClsSettings(MyDbContext ctx)
        {
            context = ctx;
        }
        public TBSettings GetAll()
        {
            try
            {
                var lstCategories = context.TBSettings.FirstOrDefault();
                return lstCategories;
            }
            catch
            {
                return new TBSettings();
            }
        }

        public bool Save(TBSettings setting)
        {
            try
            {
                context.Entry(setting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
