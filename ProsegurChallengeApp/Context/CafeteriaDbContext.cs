using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.Models;
using ProsegurChallengeApp.Seeders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Context
{
    public class CafeteriaDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }       
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<ItemMateriaPrima> ItemsMateriasPrimas { get; set; }
        public DbSet<ProvinciaImpuesto> ProvinciasImpuestos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenItem> OrdenesItems { get; set; }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseInMemoryDatabase( databaseName: "CafeteriaDb" );
        }                
    }
}
