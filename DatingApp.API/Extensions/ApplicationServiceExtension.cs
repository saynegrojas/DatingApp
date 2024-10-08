using DatingApp.API.Data;
using DatingApp.API.Helpers;
using DatingApp.API.Interfaces;
using DatingApp.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.API.Extensions
{
    // this class will contain all the added services we added in our startup class instead of having them all inside startup
    // we can call the method in startup class
    // static means we do not have to create an instance of this class to use it
    public static class ApplicationServiceExtension
    {
        // using this in param?
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration config)
        {

            // add service for JWT
            services.AddScoped<ITokenService, TokenService>();

            // add repo
            services.AddScoped<IUserRepository, UserRepository>();

            // add automapper (map 1 object to another)
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            // connect to our db
            services.AddDbContext<DataContext>(options => options.UseSqlite(config.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}