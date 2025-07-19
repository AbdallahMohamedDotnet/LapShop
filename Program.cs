using BL;
using BL.Icontract;
using LapShopv2.BL;
using LapShopv2.BL.Icontract;
using LapShopv2.Models;
using LapShopv2.Models.IContract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static BL.ItemImage;

namespace LapShopv2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // setup the dependency injection for the database context and repositories
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





            // secure website with identity features
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<MyDbContext>()
            .AddDefaultTokenProviders();

            // setup the dependency injection for the repositories
            builder.Services.AddScoped<I_DB_TBItem, ClsItem>();
            builder.Services.AddScoped<I_DB_TB_category, ClsCategories>();
            builder.Services.AddScoped<I_DB_ItemType, ClsItemTypes>();
            builder.Services.AddScoped<I_DB_Os, ClsOs>();
            builder.Services.AddScoped<IItemImages, ClsItemImages>();
            builder.Services.AddScoped<IVmHomePage, VmHomePage>();
            builder.Services.AddScoped<ISalesInvoice, ClsSalesInvoice>();
            builder.Services.AddScoped<ISalesInvoiceItems, ClsSalesInvoiceItems>();
            builder.Services.AddScoped<ISettings, ClsSettings>();
            builder.Services.AddScoped<ISliders, ClsSliders>();
            builder.Services.AddScoped<IApiResponse, ApiResponse>();

            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();
            // Configure session options and cookie settings
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Users/Login";
                //options.LogoutPath = "/Users/Logout";
                options.AccessDeniedPath = "/Users/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.SlidingExpiration = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            #region Routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "LandingPages",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion

            app.Run();
        }
    }
}

