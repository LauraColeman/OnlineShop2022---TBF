using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop2022.Data;
using OnlineShop2022.Helpers;
using OnlineShop2022.Models;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace OnlineShop2022
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Images>();
            services.AddControllersWithViews();
          

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnectionString"));
            });
            services.AddIdentity<CustomUserModel, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

            services.AddAuthentication()
                    .AddGoogle(options =>
                    {
                        options.ClientId = "162304518691-59n88b82gjnon60rud6e7nbktsv72f86.apps.googleusercontent.com";
                        options.ClientSecret = "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";
                    });

            services.AddScoped<ShoppingCartModel>(sp => ShoppingCartModel.GetCart(sp));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddSession();



            StripeConfiguration.ApiKey = "sk_test_51KSqXzKY0LFPGSfiFxp7NftS818peyPNq6LW7axdrmwVvJVQIr9e0euHpUqeJI1yCOOFU0Ok5Df7r73q0t7b7Gaf00M9v8rJGE";

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();
           

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapRazorPages();

                

                endpoints.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "product",
                    pattern: "{area:exists}/{contoller=Product}/{action=Index}/{id?}");

                


               
            });
        }
    }
}
