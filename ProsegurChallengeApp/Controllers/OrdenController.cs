using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProsegurChallengeApp.Context;
using ProsegurChallengeApp.Models;

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
            var provincias = _dbContext.Provincias.Select
            ( x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre } ).ToList();

            provincias.Insert( 0, new SelectListItem { Value = null, Text = string.Empty } );            

            ViewBag.Provincias = provincias;

            Orden orden = new Orden();
            orden.Items = _dbContext.Items.ToList();

            return View( orden );
        }

        [HttpPost]
        [Route( "CrearOrden" )]
        public async Task<IActionResult> CrearOrden( [FromForm] Orden orden, [FromForm] IFormCollection fc )
        {
            if ( ModelState.IsValid )
            {                
                Orden nuevaOrden = new Orden();
                nuevaOrden.Id = Guid.NewGuid();
                nuevaOrden.Descripcion = orden.Descripcion;
                
                var items = fc["items"];                
                List<Item> itemsSeleccionados = _dbContext.Items.Where( i => items.ToList().Contains( i.Id.ToString() ) ).ToList<Item>();
                
                nuevaOrden.Items = itemsSeleccionados;  

                _dbContext.Ordenes.Add( nuevaOrden );
                await _dbContext.SaveChangesAsync();

                return RedirectToAction( "Index", "Home" );
            }

            return View();
        }



        //[HttpPost]
        //[Route( "CrearOrden" )]
        //public async Task<IActionResult> CrearOrden( [FromForm] Orden orden )
        //{
        //    if ( ModelState.IsValid )
        //    {                
        //        return RedirectToAction( "Index", "Home" );
        //    }

        //    return View();
        //}

        //[HttpGet]
        //[Route( "GetOrdenes" )]
        //public async Task<IActionResult> GetOrdenes()
        //{
        //    return Ok( await _dbContext.Ordenes.ToListAsync() );
        //}       
    }
}