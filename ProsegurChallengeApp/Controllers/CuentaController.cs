using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsegurChallengeApp.Models;
using System.Security.Claims;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Models;
using ProsegurChallengeApp_BAL.Interfaces;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route( "Cuenta" )]
    public class CuentaController : Controller
    { 
        private readonly CafeteriaDbContext _dbContext;
        private readonly IUsuarioBC _usuarioBC;

        public CuentaController( CafeteriaDbContext dbContext, IUsuarioBC usuarioBC )
        {
            _dbContext = dbContext;
            _usuarioBC = usuarioBC;
        }

        [Route( "Login" )]
        [ApiExplorerSettings( IgnoreApi = true )]        
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
        [ApiExplorerSettings( IgnoreApi = true )]
        public async Task<IActionResult> Login( [FromForm] UsuarioLogin usuario )
        {
            try
            {                
                Usuario? validaUsuario = _usuarioBC.UsuarioValido( usuario.Nombre, usuario.Password ).Result;

                if ( validaUsuario != null )
                {
                    List<Claim> c = new List<Claim>()
                                {
                                    new Claim(ClaimTypes.NameIdentifier, validaUsuario.Id.ToString()),
                                    new Claim(ClaimTypes.Name, validaUsuario.Nombre),
                                    new Claim(ClaimTypes.StateOrProvince, validaUsuario.IdProvincia.ToString())
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
    }
}
