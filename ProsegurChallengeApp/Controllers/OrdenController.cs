using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProsegurChallengeApp.Context;
using ProsegurChallengeApp.Models;
using System.Security.Claims;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route( "Orden" )]
    public class OrdenController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;

        public OrdenController( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        private IEnumerable<SelectListItem> GetListItemProvincias()
        {            
            var provincias = _dbContext
                        .Provincias.ToList()
                        .Select( x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Nombre
                                } );

            return new SelectList( provincias, "Value", "Text" );
        }

        [ApiExplorerSettings( IgnoreApi = true )]
        [HttpGet]
        [Route( "Index" )]
        public IActionResult Index()
        {
            var idProvinciaUsuario = HttpContext.User.Claims.First( x => x.Type == ClaimTypes.StateOrProvince ).Value.ToString();
            
            var provincias = _dbContext.Provincias.Select
                            ( x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre } ).ToList();

            ViewBag.Provincias = provincias;

            Orden orden = new Orden();
            orden.Items = _dbContext.Items.ToList();
            orden.IdProvincia = int.Parse( idProvinciaUsuario );

            return View( orden );
        }

        [HttpPost]
        [Route( "CrearOrden" )]
        public async Task<IActionResult> CrearOrden( OrdenABM orden )
        {
            int idOrden = ( !_dbContext.Ordenes.Any() ? 0 : _dbContext.Ordenes.Max( o => o.Id ) ) + 1;

            Orden nuevaOrden = new Orden();
            nuevaOrden.Id = idOrden;
            nuevaOrden.Descripcion = orden.Descripcion;            

            foreach ( var idItem in orden.IdsItem )
            {
                OrdenItem ordenItem = new OrdenItem() { IdOrden = idOrden, IdItem = idItem };
                _dbContext.OrdenesItems.Add( ordenItem );
                await _dbContext.SaveChangesAsync();
            }
            
            var porcentajeImpuestoProvincia = _dbContext.ProvinciasImpuestos.First( p => p.IdProvincia == orden.IdProvincia ).PorcentajeImpuesto;

            nuevaOrden.Importe = _dbContext.Items.Where( i => orden.IdsItem.ToList().Contains( i.Id ) ).Sum( i => i.Precio ) * ( 1 + decimal.Parse( porcentajeImpuestoProvincia.ToString() ) / 100 );
            nuevaOrden.TiempoRealizacion = _dbContext.Items.Where( i => orden.IdsItem.ToList().Contains( i.Id ) ).Sum( i => i.TiempoRealizacion );
            nuevaOrden.IdProvincia = orden.IdProvincia;
            nuevaOrden.IdUsuario = int.Parse( HttpContext.User.Claims.First( x => x.Type == ClaimTypes.NameIdentifier ).Value.ToString() );
            nuevaOrden.Fecha = DateTime.Now;

            _dbContext.Ordenes.Add( nuevaOrden );
            return Ok( await _dbContext.SaveChangesAsync() );
        }

        [HttpPost]
        [Route( "GetOrdenes" )]
        public async Task<IActionResult> GetOrdenes( OrdenFiltro ordenFiltro )
        {
            List<OrdenFiltro> ordenesView = new List<OrdenFiltro>();            

            List<Orden> ordenesFiltradas = _dbContext.Ordenes.Where(
                                                o => ( string.IsNullOrEmpty( ordenFiltro.Descripcion ) || o.Descripcion.ToUpper().Contains( ordenFiltro.Descripcion.ToUpper() ) ) &&
                                                     ( ordenFiltro.IdProvincia == null || o.IdProvincia == ordenFiltro.IdProvincia ) &&
                                                     ( string.IsNullOrEmpty( ordenFiltro.Usuario ) || _dbContext.Usuarios.Where( u => u.Nombre.ToUpper().Contains( ordenFiltro.Usuario.ToUpper() ) ).Select( u => u.Id ).Contains( o.Id ) )
                                           ).ToList();

            foreach ( var orden in ordenesFiltradas )
            {
                OrdenFiltro ordenView = new OrdenFiltro();
                ordenView.Id = orden.Id;
                ordenView.Descripcion = orden.Descripcion;
                ordenView.Provincia = _dbContext.Provincias.First( p => p.Id == orden.IdProvincia ).Nombre;
                ordenView.Importe  = orden.Importe;
                ordenView.TiempoRealizacion = orden.TiempoRealizacion;
                ordenView.Usuario = _dbContext.Usuarios.First( u => u.Id == orden.IdUsuario ).Nombre;
                ordenView.Fecha = orden.Fecha;

                ordenesView.Add( ordenView );
            }            

            var response = await Task.Run( () => ordenesView );
            return Json( response );
        }

        [HttpGet]
        [Route( "GetOrdenesItems" )]
        public async Task<IActionResult> GetOrdenesItems()
        {            
            var response = await _dbContext.OrdenesItems.ToListAsync();
            return Json( response );
        }
    }
}