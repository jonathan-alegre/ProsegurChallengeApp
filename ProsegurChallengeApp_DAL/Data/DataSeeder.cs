using ProsegurChallengeApp_DAL.Models;

namespace ProsegurChallengeApp_DAL.Data
{
    public static class DataSeeder
    {
        public static async Task SeedData( CafeteriaDbContext context )
        {
            await SeedProvincias( context );
            await SeedUsuarios( context );
            await SeedItems( context );
            await SeedMateriasPrimas( context );
            await SeedItemsMateriasPrimas( context );
            await SeedProvinciasImpuestos( context );
        }

        public static async Task SeedProvincias( CafeteriaDbContext context )
        {
            var provincias = new List<Provincia>
            {
                new Provincia { Id=1, Nombre = "Buenos Aires" },
                new Provincia { Id=2, Nombre = "Córdoba" },
                new Provincia { Id=3, Nombre = "Santa Fe" },
                new Provincia { Id=4, Nombre = "Entre Ríos" },
                new Provincia { Id=5, Nombre = "Tierra del Fuego" },
                new Provincia { Id=6, Nombre = "Neuquén" },
                new Provincia { Id=7, Nombre = "San Luis" }
            };

            context.Provincias.AddRange( provincias );
            await context.SaveChangesAsync();
        }

        public static async Task SeedUsuarios( CafeteriaDbContext context )
        {
            var usuarios = new List<Usuario>
            {
                new Usuario { Id=1, Nombre = "admin", Password="1234", IdProvincia=1, Rol="Administrador" },
                new Usuario { Id=2, Nombre = "jonialegre", Password="1234", IdProvincia=2, Rol="Usuario" },                
            };

            context.Usuarios.AddRange( usuarios );
            await context.SaveChangesAsync();
        }

        public static async Task SeedProvinciasImpuestos( CafeteriaDbContext context )
        {
            var provinciasImpuestos = new List<ProvinciaImpuesto>
            {
                new ProvinciaImpuesto { IdProvincia=1, PorcentajeImpuesto = 5 },
                new ProvinciaImpuesto { IdProvincia=2, PorcentajeImpuesto = 7.5m },
                new ProvinciaImpuesto { IdProvincia=3, PorcentajeImpuesto = 6.8m },
                new ProvinciaImpuesto { IdProvincia=4, PorcentajeImpuesto = 5 },
                new ProvinciaImpuesto { IdProvincia=5, PorcentajeImpuesto = 10 },
                new ProvinciaImpuesto { IdProvincia=6, PorcentajeImpuesto = 12 },
                new ProvinciaImpuesto { IdProvincia=7, PorcentajeImpuesto = 4.5m },
            };

            context.ProvinciasImpuestos.AddRange( provinciasImpuestos );
            await context.SaveChangesAsync();
        }

        public static async Task SeedItems( CafeteriaDbContext context )
        {
            var items = new List<Item>
            {
                new Item { Id=1, Descripcion = "Café Expreso", Precio=750, TiempoRealizacion=15 },
                new Item { Id=2, Descripcion = "Café Americano", Precio=600, TiempoRealizacion=10 },
                new Item { Id=3, Descripcion = "Macchiato", Precio=1100, TiempoRealizacion=20 },
                new Item { Id=4, Descripcion = "Flat White", Precio=1200, TiempoRealizacion=18 },
                new Item { Id=5, Descripcion = "Lágrima", Precio=700, TiempoRealizacion=10 },
                new Item { Id=6, Descripcion = "Mocaccino", Precio=1300, TiempoRealizacion=20 },
                new Item { Id=7, Descripcion = "Medialuna", Precio=300, TiempoRealizacion=2 },
                new Item { Id=8, Descripcion = "Muffin Vainilla Chocochips", Precio=1200, TiempoRealizacion=2 }
            };

            context.Items.AddRange( items );
            await context.SaveChangesAsync();
        }

        public static async Task SeedMateriasPrimas( CafeteriaDbContext context )
        {
            var materiasPrimas = new List<MateriaPrima>
            {
                new MateriaPrima { Id=1, Descripcion = "Café Arlistán", Precio= 453.75m, Cantidad=1 },
                new MateriaPrima { Id=2, Descripcion = "Café Colombiano Juan Valdez", Precio=3275.5m, Cantidad=1 },
                new MateriaPrima { Id=3, Descripcion = "Leche en Polvo", Precio=375.1m, Cantidad=1 },
                new MateriaPrima { Id=4, Descripcion = "Canela", Precio=2575.4m, Cantidad=1 },
                new MateriaPrima { Id=5, Descripcion = "Azúcar", Precio=230, Cantidad=2 },
                new MateriaPrima { Id=6, Descripcion = "Chocolate Águila", Precio=380.45m, Cantidad=1 },
                new MateriaPrima { Id=7, Descripcion = "Medialuna", Precio=100, Cantidad=3 },
                new MateriaPrima { Id=8, Descripcion = "Muffin Vainilla Chocochips", Precio=300, Cantidad=4 }
            };

            context.MateriasPrimas.AddRange( materiasPrimas );
            await context.SaveChangesAsync();
        }

        public static async Task SeedItemsMateriasPrimas( CafeteriaDbContext context )
        {
            var itemsMateriasPrimas = new List<ItemMateriaPrima>
            {
                //Café Expreso
                new ItemMateriaPrima{ IdItem=1, IdMateriaPrima=2, CantidadMateriaPrima=0.120m },
                new ItemMateriaPrima{ IdItem=1, IdMateriaPrima=3, CantidadMateriaPrima=0.1m },
                new ItemMateriaPrima{ IdItem=1, IdMateriaPrima=4, CantidadMateriaPrima=0.01m },
                new ItemMateriaPrima{ IdItem=1, IdMateriaPrima=5, CantidadMateriaPrima=0.01m },
                //Café Americano
                new ItemMateriaPrima{ IdItem=2, IdMateriaPrima=1, CantidadMateriaPrima=0.120m },
                new ItemMateriaPrima{ IdItem=2, IdMateriaPrima=5, CantidadMateriaPrima=0.01m },
                //Macchiato
                new ItemMateriaPrima{ IdItem=3, IdMateriaPrima=2, CantidadMateriaPrima=0.120m },
                new ItemMateriaPrima{ IdItem=3, IdMateriaPrima=3, CantidadMateriaPrima=0.2m },
                new ItemMateriaPrima{ IdItem=3, IdMateriaPrima=4, CantidadMateriaPrima=0.05m },
                new ItemMateriaPrima{ IdItem=3, IdMateriaPrima=5, CantidadMateriaPrima=0.01m },
                //FlatWhite
                new ItemMateriaPrima{ IdItem=4, IdMateriaPrima=1, CantidadMateriaPrima=0.5m },
                new ItemMateriaPrima{ IdItem=4, IdMateriaPrima=3, CantidadMateriaPrima=0.5m },
                new ItemMateriaPrima{ IdItem=4, IdMateriaPrima=5, CantidadMateriaPrima=0.2m },
                 //Lagrima
                new ItemMateriaPrima{ IdItem=5, IdMateriaPrima=1, CantidadMateriaPrima=0.2m },
                new ItemMateriaPrima{ IdItem=5, IdMateriaPrima=3, CantidadMateriaPrima=0.5m },
                new ItemMateriaPrima{ IdItem=5, IdMateriaPrima=5, CantidadMateriaPrima=0.1m },
                //Mocaccino
                new ItemMateriaPrima{ IdItem=6, IdMateriaPrima=2, CantidadMateriaPrima=0.120m },
                new ItemMateriaPrima{ IdItem=6, IdMateriaPrima=3, CantidadMateriaPrima=0.4m },                
                new ItemMateriaPrima{ IdItem=6, IdMateriaPrima=5, CantidadMateriaPrima=0.1m },
                new ItemMateriaPrima{ IdItem=6, IdMateriaPrima=6, CantidadMateriaPrima=0.5m },                               
                //Medialuna
                new ItemMateriaPrima{ IdItem=7, IdMateriaPrima=7, CantidadMateriaPrima=1 },
                //Muffin Vainilla Chocochips
                new ItemMateriaPrima{ IdItem=8, IdMateriaPrima=8, CantidadMateriaPrima=1 },
            };

            context.ItemsMateriasPrimas.AddRange( itemsMateriasPrimas );
            await context.SaveChangesAsync();
        }
    }
}
