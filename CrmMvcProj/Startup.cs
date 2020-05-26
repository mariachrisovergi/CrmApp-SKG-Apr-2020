using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrmApp.Repository;
using CrmApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CrmMvcProj
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
            // Definition of injections
            services.AddDbContext<CrmDbContext>(options =>  options.UseSqlServer(CrmDbContext.ConnectionString));

            services.AddScoped<ICustomerManager, CustomerManagement>();
            services.AddScoped<IProductManager, ProductManagement>();
            services.AddScoped<IBasketManager, BasketManagement>();

            services.AddControllersWithViews();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            { 
                app.UseStatusCodePagesWithRedirects("/Home/Error");
          //      app.UseDeveloperExceptionPage();
              }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Home/Error");
             //    app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapControllerRoute(
                     name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
          



            });
        }
    }
}
