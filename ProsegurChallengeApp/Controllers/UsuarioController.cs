using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_BAL.BALClasses;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_BAL.OrdenBAL;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Entities;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route( "Usuario" )]
    public class UsuarioController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;
        private readonly IProvinciaBC _provinciaBC;
        private readonly IUsuarioBC _usuarioBC;

        public UsuarioController( CafeteriaDbContext dbContext, IProvinciaBC provinciaBC, IUsuarioBC usuarioBC )
        {
            _dbContext = dbContext;
            _provinciaBC = provinciaBC;
            _usuarioBC = usuarioBC;
        }        

        [ApiExplorerSettings( IgnoreApi = true )]
        [Route( "Index" )]
        public IActionResult Index()
        {
            var provincias = _provinciaBC.GetListItemProvincias().ToList();

            Utils.Utils.InsertNullValueToListItem( provincias );

            ViewBag.Provincias = provincias;

            return View();
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario( Usuario usuario )
        {
            return await _usuarioBC.CrearUsuario( usuario );
        }                
    }
}