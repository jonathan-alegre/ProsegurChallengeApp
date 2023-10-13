using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.Models;
using ProsegurChallengeApp.Seeders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;

namespace ProsegurChallengeApp.Context
{
    public class CafeteriaDbContext : DbContext
    {        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Provincia> Provincias { get; set; }        

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseInMemoryDatabase( databaseName: "CafeteriaDb" );           
        }
    }
}
