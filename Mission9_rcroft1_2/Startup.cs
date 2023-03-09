using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_rcroft1_2.Models;

namespace Mission9_rcroft1_2
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }


        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); // uses mvc pattern

            services.AddDbContext<BookStoreContext>(options =>
            {

                // connectionStrings
                options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);

            });

            services.AddScoped<IBookStoreRepository, EFBookStoreRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();  // tells it to use wwwroot

            app.UseSession(); //makes it use sessions for the basket

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "typepage", "{bookType}/Page{pageBook}",
                    new {Controller = "Home", action = "Index"}
                    );

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageBook}",
                    defaults: new { Controller = "Home", action = "Index", pageBook = 1 });

                endpoints.MapControllerRoute("type",
                "{bookType}",
                new { Controller = "Home", action = "Index", pageBook = 1 });
                
                endpoints.MapDefaultControllerRoute(); // routes to controller and url stuff

                endpoints.MapRazorPages();
            });
        }
    }
}
