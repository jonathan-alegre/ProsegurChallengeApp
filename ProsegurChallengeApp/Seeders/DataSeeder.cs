using ProsegurChallengeApp.Context;
using ProsegurChallengeApp.Models;

namespace ProsegurChallengeApp.Seeders
{
    public static class DataSeeder
    {        
        public static async Task SeedUsuarios( CafeteriaDbContext context )
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { Id=2, Nombre = "jonathanalegre", Password="1234", Rol="Usuario" },
                new Usuario { Id=3, Nombre = "admin", Password="admin", Rol="Administrador" }
            };

            context.Usuarios.AddRange( usuarios );
            await context.SaveChangesAsync();
        }

        public static async Task SeedProvincias( CafeteriaDbContext context )
        {
            var provincias = new List<Provincia>
            {
                new Provincia { Id=Guid.NewGuid(), Nombre = "jonathanalegre" },
                new Provincia { Id=Guid.NewGuid(), Nombre = "admin" }
            };

            context.Provincias.AddRange( provincias );
            await context.SaveChangesAsync();
        }
    }
}
