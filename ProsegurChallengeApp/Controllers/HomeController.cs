using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProsegurChallengeApp.Controllers
{
    [Route( "Home" )]
    [ApiController]
    [Authorize]
    public class HomeController : Controller
    {
        [Route( "Index" )]
        [ApiExplorerSettings( IgnoreApi = true )]
        public IActionResult Index()
        {
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
