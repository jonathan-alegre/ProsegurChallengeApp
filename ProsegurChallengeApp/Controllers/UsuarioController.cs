using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.DataBaseContext;
using ProsegurChallengeApp.Models;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;

        public UsuarioController(CafeteriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[HttpPost]
        //[Route( "CreateUsuarios" )]
        //public async Task<IActionResult> CreateUsuarios()
        //{
        //    Usuario usuario = new Usuario();
        //    usuario.Id = Guid.NewGuid();
        //    usuario.Nombre = "Jonathan Alegre";

        //    _dbContext.Usuarios.Add( usuario );

        //    usuario = new Usuario();
        //    usuario.Id = Guid.NewGuid();
        //    usuario.Nombre = "Maximiliano Barrera";

        //    _dbContext.Usuarios.Add( usuario );

        //    _dbContext.SaveChanges();

        //    return Content( "Usuarios Creados" );
        //}

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CrearUsuario([FromForm] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();

                _dbContext.Usuarios.Add(usuario);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Index");
            }

            return View();
        }

        [HttpGet]
        [Route("GetUsuariosList")]
        public async Task<IActionResult> GetUsuariosList()
        {
            return Ok(await _dbContext.Usuarios.ToListAsync());
        }
    }
}
