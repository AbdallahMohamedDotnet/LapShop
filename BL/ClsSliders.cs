using LapShopv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Icontract;
namespace BL
{


    public class ClsSliders : ISliders
    {
        MyDbContext context;
        public ClsSliders(MyDbContext ctx)
        {
            context = ctx;
        }
        public List<TbSlider> GetAll()
        {
            try
            {
                var lstCategories = context.TbSliders.Where(a => a.CurrentState == 1).ToList();
                return lstCategories;
            }
            catch
            {
                return new List<TbSlider>();
            }
        }

        public TbSlider GetById(int id)
        {
            try
            {
                var os = context.TbSliders.FirstOrDefault(a => a.SliderId == id && a.CurrentState == 1);
                return os;
            }
            catch
            {
                return new TbSlider();
            }
        }

        public bool Save(TbSlider os)
        {
            try
            {
                if (os.SliderId == 0)
                {
                    //os.CreatedBy = "1";
                    //os.CreatedDate = DateTime.Now;
                    context.TbSliders.Add(os);
                }
                else
                {
                    //os.UpdatedBy = "1";
                    //os.UpdatedDate = DateTime.Now;
                    context.Entry(os).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Dekete(int id)
        {
            try
            {
                var os = GetById(id);
                os.CurrentState = 0;
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
