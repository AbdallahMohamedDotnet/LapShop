using LapShopv2.Models; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LapShopv2.BL;
using LapShopv2.BL.Icontract;
namespace LapShopv2.BL
{
    public class ClsCategories : I_DB_TB_category
    {
        public ClsCategories(MyDbContext context)
        {
            this.context = context;
        }
        MyDbContext context;
        
        public List<TbCategory> GetAll()
        {
            try
            {                    
                var lstCategories = context.TbCategories.Where(a => a.CurrentState == 1).ToList();
                return lstCategories;
                
            }
            catch
            {
                return new List<TbCategory>();
            }
        }

     
        public TbCategory GetById(int id)
        {
            try
            {

                    var category = context.TbCategories.FirstOrDefault(a => a.CategoryId == id);
                    return category ?? new TbCategory();
                
            }
            catch
            {
                return new TbCategory();
            }
        }


        public bool Save(TbCategory category)
        {
            try
            {
                if (category.CategoryId == 0)
                {
                    category.CreatedBy = "1";
                    category.CreatedDate = DateTime.Now;
                    context.TbCategories.Add(category);
                }
                else
                {
                    category.UpdatedBy = "1";
                    category.UpdatedDate = DateTime.Now;
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                category.CurrentState = 1; 
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
                var category = GetById(id);
                category.CurrentState = 0;
                context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

