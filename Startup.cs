using ItMightBeAmazon.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItMightBeAmazon
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
            services.AddControllersWithViews();

            //configure the database
            services.AddDbContext<BookSiteDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookSiteConnection"]);
            });

            services.AddScoped<IBookRepository, EFBookRepository>();

            //Allows the use of Razor Pages
            services.AddRazorPages();

            //These two services allow us to use sessions for the cart
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //set up a session upon startup
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //end points have been changed to show /P{page} (i.e. /P2 for page 2), 
            //and allow for the category and page to be input into the url as well as just the category or page.
            //endpoints also display the category in the url once the user has used it to filter results
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "/P{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                //enpoint for razor pages
                endpoints.MapRazorPages();
            });

            //add the SeedData
            SeedData.EnsurePopulated(app);
        }
    }
}
