using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DatingApp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    // get data out of json file & put in our db
    public class Seed
    {
    // returns void so no type
        public static async Task SeedUsers(DataContext context) {
            // check if table contains users
            // return if there are any users in our db
            if(await context.Users.AnyAsync()) return; 

            // continue : no users in our table
            // go to the json file & store in a variable
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            // getting json out(deserialize) of userData to an object
            // we must put in a List since it's an array of users & returns of type AppUser
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            // for each user, add a hardcoded password
            foreach (var user in users) {

                // we still need to provide(hard code) passwords(hash & salt) for each user (for now each user has the same pw)
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);

            }
            await context.SaveChangesAsync();

            // We call this SeedUsers method in our program MAIN method to load to our db before our app starts
        }
    }
}