using BookStore_App.Data;
using BookStore_App.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(); //for MVC
            services.AddDbContext<BookStoreContext>( 
                options=>options.UseSqlServer("Server=.\\SQLEXPRESS;Database=BookStore;Integrated Security=True;")); //SQL server Database Connection
#if DEBUG
            services.AddRazorPages().AddRazorRuntimeCompilation(); // For run time compilation
#endif
            services.AddScoped<BookRepository, BookRepository>(); //dependencies injection for book repository and used this dependencies inside the bookController.
                                                                  // for inserting data you must have to create dependency injection

            services.AddScoped<languageRepo, languageRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("first middleware");

                await next();

                await context.Response.WriteAsync("Response from first middleware");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("second middleware");

                await next();

                await context.Response.WriteAsync("Response from second middleware");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("third middleware");

            });
            */
            app.UseStaticFiles();

             app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.Map("/", async context =>
                 {
                  await context.Response.WriteAsync("Hello World!");
                 }); */

                endpoints.MapDefaultControllerRoute(); // data come from the controller
             });
        }
    }
}
