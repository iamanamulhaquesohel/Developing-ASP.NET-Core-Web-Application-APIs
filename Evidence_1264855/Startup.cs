using Evidence_1264855.Models;
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

namespace Evidence_1264855
{
    public class Startup
    {
        public Startup(IConfiguration Config) { this.Configuration = Config; }
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Database Context and Connection String
            services.AddDbContext<CompanyDbContext>(option => option.UseSqlServer(this.Configuration.GetConnectionString("DbConfig")));
            //Add Mvc Service
            services.AddControllersWithViews();
            //Add Runtime Compilation Service
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(
            //         Path.Combine(env.ContentRootPath, "MyStaticFiles")),
            //    RequestPath = "/StaticFiles"
            //});

            app.UseEndpoints(endpoints =>
            {
                //MVC Default Routing
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
