using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.Interfaces
{
    public interface IUsuarioDA
    {
        Task<Usuario> UsuarioValido( string nombre, string password );
        Task CrearUsuario( Usuario usuario );
        int GetNuevoId();
    }
}
