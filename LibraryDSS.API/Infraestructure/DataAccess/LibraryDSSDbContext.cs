using LibraryDSS.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace LibraryDSS.API.Infraestructure.DataAccess
{
    public class LibraryDSSDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Checkout> Checkouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\gvalm\\source\\repos\\Library\\LibraryDSS.API\\BD\\TechLibraryDb.db");


        }
    }
}
