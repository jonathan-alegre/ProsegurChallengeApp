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
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync( CookieAuthenticationDefaults.AuthenticationScheme );
            return RedirectToAction( "Login" , "Cuenta" );
        }       

        public IActionResult Privacy()
        {
            return View();
        }      
    }
}
