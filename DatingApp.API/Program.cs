using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API
{
    public class Program
    {
        // every program has program.cs calls and contains a single method
        // dotnet run looks for a program class and runs the main method inside Main()
        // Main method has one job, to call another method inside CreateHostBuilder
        // ORIGINAL 
        // public static void Main(string[] args)
        // {
        //     CreateHostBuilder(args).Build().Run();
        // }
        

        // change void to async Task since we're needing a session with the DB
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // create scope services to get DataContext service
            using var scope = host.Services.CreateScope();

            // service for SP
            var services = scope.ServiceProvider;

            // need try/catch to catch any exception since we're outside the startup class middleware
            try
            {
                // get service of DataContext
                var context = services.GetRequiredService<DataContext>();

                // restart app to apply any tracked migrations
                await context.Database.MigrateAsync();

                // access Seed class to call SeedUsers method
                await Seed.SeedUsers(context);

            }
            catch (Exception ex)
            {
                // log any errors during migration
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }
            // RUN app
            await host.RunAsync();
        }
        // CreateHostBuilder method configues some defaults
        // tells our app to use kestrel web server provided by dotnetcore that's hosting our API
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            // configure logging - log in terminal console (info: )
            // reads from config files which contain our app.settings.Development
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // can provide addtional config for our app (Startup class)
                    webBuilder.UseStartup<Startup>();
                });
    }
}
