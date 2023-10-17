using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_BAL.OrdenBAL;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Entities;
using ProsegurChallengeApp_DAL.Interfaces;
using ProsegurChallengeApp_DAL.Models;
using ProsegurChallengeApp_DAL.OrdenDAL;
using System.Security.Claims;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route( "Orden" )]
    public class OrdenController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;
        private readonly IOrdenBC _ordenBC;
        private readonly IProvinciaBC _provinciaBC;

        public OrdenController( CafeteriaDbContext dbContext, IOrdenBC ordenBC, IProvinciaBC provinciaBC )
        {
            _dbContext = dbContext;
            _ordenBC = ordenBC;
            _provinciaBC = provinciaBC;
         } 

        [ApiExplorerSettings( IgnoreApi = true )]
        [HttpGet]
        [Route( "Index" )]
        public IActionResult Index()
        {
            var idProvinciaUsuario = HttpContext.User.Claims.First( x => x.Type == ClaimTypes.StateOrProvince ).Value.ToString();

            var provincias = _provinciaBC.GetListItemProvincias();

            ViewBag.Provincias = provincias;

            OrdenViewModel orden = new OrdenViewModel();
            orden.Items = _dbContext.Items.ToList();
            orden.IdProvincia = int.Parse( idProvinciaUsuario );

            return View( orden );
        }

        [HttpPost]
        [Route( "CrearOrden" )]
        public async Task<IActionResult> CrearOrden( OrdenABMDto orden )
        {
            orden.IdUsuario = int.Parse( HttpContext.User.Claims.First( x => x.Type == ClaimTypes.NameIdentifier ).Value.ToString() );
            return await _ordenBC.CrearOrden(orden);            
        }

        [HttpPost]
        [Route( "GetOrdenes" )]
        public async Task<IActionResult> GetOrdenes( OrdenFiltroDto ordenFiltro )
        {          
            var response = await Task.Run( () => _ordenBC.GetOrdenes( ordenFiltro ) );
            return Json( response );
        }        
    }
}