using Microsoft.EntityFrameworkCore;
using Test_ConsoleApp.DataAccess.Entity;

namespace Test_ConsoleApp.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagToUser> TagsToUser { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Db_TestConsolApp;Trusted_Connection=True;");
        }
    }
}
