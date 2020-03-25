using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DatingApp.API
{
    public class Program
    {
        // every program has program.cs calls and contains a single method
        // dotnet run looks for a program class and runs the main method inside Main()
        // Main method has one job, to call another method inside CreateHostBuilder
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
