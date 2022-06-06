using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductManagementSystem.Services;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProductManagementSystem
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
            //services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepository, DBData>();
            //services.AddDbContext<ProductContext>(options => options.UseSqlite("Data Source = Employees.db"));
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(@"Server=DESKTOP-31VIBLR\SQLEXPRESS;Database=ProductManagementSystem;Trusted_Connection=True; MultipleActiveResultSets=True"));
            services.AddIdentity<User, IdentityRole>(options =>
            {

                options.Password.RequiredLength = 8;

            }).AddEntityFrameworkStores<UserContext>();
            services.AddDbContext<UserContext>(options => options.UseSqlServer(@"Server=DESKTOP-31VIBLR\SQLEXPRESS;Database=PCAD6Users;Trusted_Connection=True; MultipleActiveResultSets=True"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(ProductContext productContext, IApplicationBuilder app, IWebHostEnvironment env)
        {
            productContext.Database.EnsureDeleted();
            productContext.Database.EnsureCreated();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsProduction())
            {
                app.UseExceptionHandler("/Error.html");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

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
