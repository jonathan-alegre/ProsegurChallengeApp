using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.Context;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProsegurChallengeApp.Controllers
{
    [Route( "Home" )]
    [ApiController]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;

        public HomeController( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        [Route( "Index" )]
        [ApiExplorerSettings( IgnoreApi = true )]
        public IActionResult Index()
        {
            var provincias = _dbContext.Provincias.Select
                            ( x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre } ).ToList();

            provincias.Insert( 0, new SelectListItem { Value = null, Text = null } );

            ViewBag.Provincias = provincias;

            return View();
        }

        [Route( "Salir" )]
        [ApiExplorerSettings( IgnoreApi = true )]
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync( CookieAuthenticationDefaults.AuthenticationScheme );
            return RedirectToAction( "Login" , "Cuenta" );
        }

        [ApiExplorerSettings( IgnoreApi = true )]
        public IActionResult Privacy()
        {
            return View();
        }      
    }
}
