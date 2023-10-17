using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp.Utils;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProsegurChallengeApp.Controllers
{
    [Route( "Home" )]
    [ApiController]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;
        private readonly IProvinciaBC _provinciaBC;

        public HomeController( CafeteriaDbContext dbContext, IProvinciaBC provinciaBC )
        {
            _dbContext = dbContext;
            _provinciaBC = provinciaBC;
        }

        [Route( "Index" )]
        [ApiExplorerSettings( IgnoreApi = true )]
        public IActionResult Index()
        {
            var provincias = _provinciaBC.GetListItemProvincias();
    
            Utils.Utils.InsertNullValueToListItem( provincias );

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
    }
}
