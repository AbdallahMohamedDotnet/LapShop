using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LapShopv2.BL
{
    public class ClsOs : I_DB_Os
    {
        public ClsOs(MyDbContext context)
        {
            this.context = context;
        }
        MyDbContext context;
        public List<TbO> GetAll()
        {
            try
            {
                var lstOs = context.TbOs.Where(a => a.CurrentState == 1).ToList();
                return lstOs;

            }
            catch
            {
                return new List<TbO>();
            }
        }


        public TbO GetById(int id)
        {
            try
            {

                var Os = context.TbOs.FirstOrDefault(a => a.OsId == id);
                return Os ?? new TbO();

            }
            catch
            {
                return new TbO();
            }
        }


        public bool Save(TbO Os)
        {
            try
            {
                if (Os.OsId == 0)
                {
                    Os.CreatedBy = "1";
                    Os.CreatedDate = DateTime.Now;
                    Os.CurrentState = 1;
                    context.TbOs.Add(Os);
                }
                else
                {
                    Os.UpdatedBy = "1";
                    Os.UpdatedDate = DateTime.Now;
                    Os.CurrentState = 1; 
                    context.Entry(Os).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var Os = GetById(id);
                Os.CurrentState = 0;
                context.Entry(Os).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete Error: " + ex.Message);
                return false;
            }
        }
    }
}
