using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DatingApp.API.Data;

namespace DatingApp.API
{
    public class Startup
    {
        // config being injected into our startup class - allows us to access the settings inside our appsettings
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // our dependeny injection 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            // whenever we create something to be consumed by another part of our app, we ADD it as a service
            // and we'll be able to inject this service somewhere else in our app
            services.AddControllers();
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // connection error for cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // everything added in here is Middleware – software can use to interact with our req as it's going through pipeline

            // condition to check if we're running on development mode
            if (env.IsDevelopment())
            {
                // if true, this method catches and returns a developer friendly exception page
                // also acts as a global exception handler and catches the exception and returns developer freindly exception page
                app.UseDeveloperExceptionPage();
            }

            // define cors policy to allow headers
            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:4200"));
            // app.UseMvc();

            // attemps to redirect to any request to https
            // app.UseHttpsRedirection();

            // middleware - to tell our app to use routing
            app.UseRouting();

            // middleware - to use authorization
            app.UseAuthorization();

            // middleware - use endpoint - as app starts, maps our controller endpoints into our app so that our app our API knows how to route request
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
