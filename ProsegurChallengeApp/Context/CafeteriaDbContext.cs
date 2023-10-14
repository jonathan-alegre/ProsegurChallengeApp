using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.Models;
using ProsegurChallengeApp.Seeders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Context
{
    public class CafeteriaDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Item> Items { get; set; }

        //protected override void OnModelCreating( ModelBuilder modelBuilder )
        //{
        //    modelBuilder.Entity<Usuario>().HasData(
        //        new Usuario
        //        {
        //            Id = Guid.NewGuid(),
        //            Nombre = "admin",
        //            Password = "admin",
        //            MantenerActivo = false
        //        }
        //    );
        //}

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            optionsBuilder.UseInMemoryDatabase( databaseName: "CafeteriaDb" );
        }

        //protected override void OnModelCreating( ModelBuilder modelBuilder )
        //{
        //    modelBuilder.Entity<Usuario>().HasData(
        //        new Usuario
        //        {
        //            Id = Guid.NewGuid(),
        //            Nombre = "admin",
        //            Password = "admin",
        //            MantenerActivo = false
        //        }
        //    );
        //}

        public DbSet<ProsegurChallengeApp.Models.Orden>? Orden { get; set; }
    }
}
