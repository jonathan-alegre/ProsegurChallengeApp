using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.Context;
using ProsegurChallengeApp.Models;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route( "Usuario" )]
    public class UsuarioController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;

        public UsuarioController( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }        

        [ApiExplorerSettings( IgnoreApi = true )]
        [Route( "Index" )]
        public IActionResult Index()
        {
            var provincias = _dbContext.Provincias.Select
            ( x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre } ).ToList();

            provincias.Insert( 0, new SelectListItem { Value = null, Text = string.Empty } );

            ViewBag.Provincias = provincias;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario( [FromForm] CrearUsuarioView usuario )
        {
            if ( ModelState.IsValid )
            {
                Usuario nuevoUsuario = new Usuario();
                nuevoUsuario.Id = ( !_dbContext.Usuarios.Any() ? 0 : _dbContext.Usuarios.Max( u => u.Id ) ) + 1;
                nuevoUsuario.Nombre = usuario.Nombre;
                nuevoUsuario.Password = usuario.Password;
                nuevoUsuario.IdProvincia = usuario.IdProvincia;
                nuevoUsuario.Rol = "Usuario";

                //var managerUsuario = WebApplication.CreateBuilder().Build().Services.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                //managerUsuario.AddToRoleAsync( nuevoUsuario, "Usuario" );

                _dbContext.Usuarios.Add( nuevoUsuario );
                await _dbContext.SaveChangesAsync();

                return RedirectToAction( "Index", "Home" );
            }

            return View();
        }

        [HttpGet]
        [Route( "GetUsuariosList" )]
        public async Task<IActionResult> GetUsuariosList()
        {
            return Ok( await _dbContext.Usuarios.ToListAsync() );
        }

        [HttpGet]
        [Route( "ValidarUsuario" )]
        public Usuario? ValidarUsuario( string nombre, string password )
        {
            return _dbContext.Usuarios.FirstOrDefault( u => u.Nombre == nombre && u.Password == password );
        }
    }
}