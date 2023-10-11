using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.DataModel;

namespace ProsegurChallengeApp.DataBaseContext
{
    public class CafeteriaDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CafeteriaDb");
        }
    }
}
