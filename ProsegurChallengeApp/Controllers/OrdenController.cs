using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [ApiExplorerSettings( IgnoreApi = true )]
        [Route( "Index" )]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route( "CrearOrden" )]
        public async Task<IActionResult> CrearOrden( [FromForm] Orden orden )
        {
            if ( ModelState.IsValid )
            {                
                return RedirectToAction( "Index", "Home" );
            }

            return View();
        }

        [HttpGet]
        [Route( "GetOrdenes" )]
        public async Task<IActionResult> GetOrdenes()
        {
            return Ok( await _dbContext.Ordenes.ToListAsync() );
        }       
    }
}