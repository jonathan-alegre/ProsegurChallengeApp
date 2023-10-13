    using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.Models;

namespace ProsegurChallengeApp.Context
{
    public class CafeteriaDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Orden> Ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CafeteriaDb");
        }
    }
}
