using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp.DataBaseContext;

namespace ProsegurChallengeApp.Controller
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly CafeteriaDbContext _dbContext;

        public UsuarioController(CafeteriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetUsuariosList")]
        public async Task<IActionResult> GetUsuariosList()
        {
            return Ok(await _dbContext.Usuarios.ToListAsync());
        }
    }
}
