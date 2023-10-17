using Microsoft.AspNetCore.Mvc;
using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.Interfaces
{
    public interface IUsuarioBC
    {
        Task<Usuario> UsuarioValido( string nombre, string password );        
        Task<IActionResult> CrearUsuario( Usuario usuario );
    }
}
