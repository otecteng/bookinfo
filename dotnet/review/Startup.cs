using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using review.Data;
using Microsoft.EntityFrameworkCore;
namespace review
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddJsonOptions(options => 
               options.JsonSerializerOptions.PropertyNamingPolicy = null);
            //通过调用 DbContextOptions 对象中的一个方法将连接字符串名称传递到上下文
            services.AddDbContext<MvcReviewContext>(options =>
        {
            var connectionString = Configuration.GetConnectionString("MvcReviewContext");

            
            if (Environment.IsDevelopment())
            {
                options.UseMySql(connectionString,Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.34-mysql"));
                //options.UseSqlite(connectionString);
            }
            else
            {
                
                options.UseMySql(connectionString,Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.34-mysql"));
            }
        });
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
                //app.UseExceptionHandler("/Home/Error");
                app.UseDeveloperExceptionPage();
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
