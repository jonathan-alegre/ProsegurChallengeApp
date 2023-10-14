using ProsegurChallengeApp.Context;
using ProsegurChallengeApp.Models;

namespace ProsegurChallengeApp.Seeders
{
    public static class DataSeeder
    {
        public static async Task SeedData( CafeteriaDbContext context )
        {
            await SeedUsuarios( context );
            await SeedProvincias( context );
            await SeedItems( context );
        }

        public static async Task SeedUsuarios( CafeteriaDbContext context )
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { Id=Guid.NewGuid(), Nombre = "jonathanalegre", Password="1234"  },
                new Usuario { Id=Guid.NewGuid(), Nombre = "admin", Password="admin" }
            };

            context.Usuarios.AddRange( usuarios );
            await context.SaveChangesAsync();
        }

        public static async Task SeedProvincias( CafeteriaDbContext context )
        {
            var provincias = new List<Provincia>
            {
                new Provincia { Id=Guid.NewGuid(), Nombre = "Buenos Aires" },
                new Provincia { Id=Guid.NewGuid(), Nombre = "Córdoba" },
                new Provincia { Id=Guid.NewGuid(), Nombre = "Santa Fe" },
                new Provincia { Id=Guid.NewGuid(), Nombre = "Entre Ríos" },
                new Provincia { Id=Guid.NewGuid(), Nombre = "Tierra del Fuego" },
                new Provincia { Id=Guid.NewGuid(), Nombre = "Neuquén" },
                new Provincia { Id=Guid.NewGuid(), Nombre = "San Luis" }
            };

            context.Provincias.AddRange( provincias );
            await context.SaveChangesAsync();
        }

        public static async Task SeedItems( CafeteriaDbContext context )
        {
            var items = new List<Item>
            {
                new Item { Id=Guid.NewGuid(), Descripcion = "Café Expreso", Precio=750, TiempoRealizacion=15 },
                new Item { Id=Guid.NewGuid(), Descripcion = "Café Americano", Precio=600, TiempoRealizacion=5 },
                new Item { Id=Guid.NewGuid(), Descripcion = "Macchiato", Precio=1100, TiempoRealizacion=20 },
                new Item { Id=Guid.NewGuid(), Descripcion = "Flat White", Precio=1200, TiempoRealizacion=18 },
                new Item { Id=Guid.NewGuid(), Descripcion = "Lágrima", Precio=700, TiempoRealizacion=10 },
                new Item { Id=Guid.NewGuid(), Descripcion = "Mocaccino", Precio=1300, TiempoRealizacion=20 },
                new Item { Id=Guid.NewGuid(), Descripcion = "Medialuna", Precio=300, TiempoRealizacion=0 },
                new Item { Id=Guid.NewGuid(), Descripcion = "Muffin Vainilla Chocochips", Precio=1200, TiempoRealizacion=0 }
            };

            context.Items.AddRange( items );
            await context.SaveChangesAsync();
        }
    }
}
