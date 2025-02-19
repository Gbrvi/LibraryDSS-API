using LibraryDSS.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;

namespace LibraryDSS.API.Infraestructure
{
    public class LibraryDSSDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\gvalm\\source\\repos\\Library\\LibraryDSS.API\\BD\\TechLibraryDb.db");


        }
    }
}
