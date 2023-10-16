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
        public async Task<IActionResult> CrearOrden( [FromForm] Orden orden, [FromForm] IFormCollection fc )
        {
            if ( ModelState.IsValid )
            {                                               
                int idOrden = ( !_dbContext.Ordenes.Any() ? 0 : _dbContext.Ordenes.Max( o => o.Id ) ) + 1;
                
                Orden nuevaOrden = new Orden();
                nuevaOrden.Id = idOrden;
                nuevaOrden.Descripcion = orden.Descripcion;
                
                var items = fc["Items"];                
                List<Item> itemsSeleccionados = _dbContext.Items.Where( i => items.ToList().Contains( i.Id.ToString() ) ).ToList<Item>();                

                foreach ( var item in itemsSeleccionados )
                {
                    OrdenItem ordenItem = new OrdenItem() { IdOrden = idOrden, IdItem = item.Id };
                    _dbContext.OrdenesItems.Add( ordenItem );
                    await _dbContext.SaveChangesAsync();                    
                }

                var idProvincia = fc["IdProvincia"].ToString();
                var porcentajeImpuestoProvincia = _dbContext.ProvinciasImpuestos.First( p => p.IdProvincia == int.Parse( idProvincia ) ).PorcentajeImpuesto;

                nuevaOrden.Importe = _dbContext.Items.Where( i => items.ToList().Contains( i.Id.ToString() ) ).Sum( i => i.Precio ) * ( 1 + decimal.Parse( porcentajeImpuestoProvincia.ToString() ) / 100 );
                nuevaOrden.TiempoRealizacion = _dbContext.Items.Where( i => items.ToList().Contains( i.Id.ToString() ) ).Sum( i => i.TiempoRealizacion );
                nuevaOrden.IdProvincia = int.Parse( idProvincia );
                nuevaOrden.IdUsuario = int.Parse( HttpContext.User.Claims.First( x => x.Type == ClaimTypes.NameIdentifier ).Value.ToString() );
                nuevaOrden.Fecha = DateTime.Now;

                _dbContext.Ordenes.Add( nuevaOrden );
                await _dbContext.SaveChangesAsync();

                return RedirectToAction( "Index", "Home" );
            }

            return View();
        }
      
        [HttpPost]
        [Route( "GetOrdenes" )]
        public async Task<IActionResult> GetOrdenes()
        {
            var response = await _dbContext.Ordenes.ToListAsync();
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