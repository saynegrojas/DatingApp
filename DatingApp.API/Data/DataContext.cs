using Microsoft.EntityFrameworkCore;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    // need to do - need to derive from entity framework called class
    // the way to do that is to add a colon after DataContext and add the class
    // class we want to derive from is DbContext
    // missing directive - need to use entity framework called assembly to get access to this class
    // cmd line - search for nuget add package - Microsoft.EntityFrameworkCore - select version - add 'using'
    public class DataContext : DbContext
    {
        // create a constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Value> Values { get; set; }

    }
}