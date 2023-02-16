using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) // this is the constructor for the DataContext class
        {
        }

        public DbSet<Activity> Activities { get; set; } // this is the table name in the database (Activities) 
    }
}