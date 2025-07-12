using System;
using System.Collections.Generic;
using System.Linq;
using LapShopv2.Models;
using Microsoft.EntityFrameworkCore;

namespace LapShopv2.BL
{
    public class ClsItemTypes : Icontract.I_DB_ItemType
    {
        
        public ClsItemTypes(MyDbContext context)
        {
            this.context = context;
        }
        MyDbContext context  ;
        public List<TbItemType> GetAll()
        {
            try
            {
                var lstItemTypes = context.TbItemTypes.Where(a => a.CurrentState == 1).ToList();
                return lstItemTypes;

            }
            catch
            {
                return new List<TbItemType>();
            }
        }


        public TbItemType GetById(int id)
        {
            try
            {

                var ItemTypes = context.TbItemTypes.FirstOrDefault(a => a.ItemTypeId == id);
                return ItemTypes ?? new TbItemType();

            }
            catch
            {
                return new TbItemType();
            }
        }


        public bool Save(TbItemType ItemTypes)
        {
            try
            {
                if (ItemTypes.ItemTypeId == 0)
                {
                    ItemTypes.CreatedBy = "1";
                    ItemTypes.CreatedDate = DateTime.Now;
                    ItemTypes.CurrentState = 1;
                    context.TbItemTypes.Add(ItemTypes);
                }
                else
                {
                    ItemTypes.UpdatedBy = "1";
                    ItemTypes.UpdatedDate = DateTime.Now;
                    ItemTypes.CurrentState = 1;
                    context.Entry(ItemTypes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                var ItemTypes = GetById(id);
                ItemTypes.CurrentState = 0;
                context.Entry(ItemTypes).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
