using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsegurChallengeApp.Context;
using ProsegurChallengeApp.Models;
using System.Security.Claims;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route( "Cuenta" )]
    public class CuentaController : Controller
    { 
        private readonly CafeteriaDbContext _dbContext;

        public CuentaController( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        [Route("Login")]
        public IActionResult Login()
        {
            ClaimsPrincipal c = HttpContext.User;
            if ( c.Identity != null )
            {
                if ( c.Identity.IsAuthenticated )
                    return RedirectToAction( "Index", "Home" );
            }
            return View();
        }

        [HttpPost]
        [Route( "Login" )]
        public async Task<IActionResult> Login( [FromForm] Usuario usuario )
        {
            try
            {
                UsuarioController usuarioController = new UsuarioController( _dbContext );

                Usuario? validaUsuario = usuarioController.ValidarUsuario( usuario.Nombre, usuario.Password );

                if ( validaUsuario != null )
                {
                    List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, usuario.Nombre)
                                };
                    ClaimsIdentity ci = new( c, CookieAuthenticationDefaults.AuthenticationScheme );
                    AuthenticationProperties p = new();

                    p.AllowRefresh = true;
                    p.IsPersistent = usuario.MantenerActivo;

                    if ( !usuario.MantenerActivo )
                        p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes( 15 );
                    else
                        p.ExpiresUtc = DateTimeOffset.UtcNow.AddHours( 1 );

                    await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal( ci ), p );
                    return RedirectToAction( "Index", "Home" );
                }
                else
                {
                    ViewBag.Error = "Datos de usuario incorrectos o no registrado.";
                }

                return View();
            }
            catch ( System.Exception e )
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        public IActionResult Details( int id )
        {
            return View();
        }      
    }
}
