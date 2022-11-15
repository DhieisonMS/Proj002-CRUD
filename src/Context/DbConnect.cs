using Microsoft.EntityFrameworkCore;

using src.Models;

namespace src.Context
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options)
        {
        }       

        public DbSet<User> User {get; set;}
    }
}