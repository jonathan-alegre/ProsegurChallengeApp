using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Interfaces;
using ProsegurChallengeApp_DAL.Models;
using ProsegurChallengeApp_DAL.OrdenDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.BALClasses
{
    public class UsuarioBC : IUsuarioBC
    {        
        public readonly IUsuarioDA _usuarioDA;

        public UsuarioBC( IUsuarioDA usuarioDA )
        {     
            _usuarioDA = usuarioDA;
        }

        public async Task<Usuario> UsuarioValido(string nombre, string password)
        {
            return await Task.Run( () => _usuarioDA.UsuarioValido( nombre, password ) );
        }

        public async Task<IActionResult> CrearUsuario( Usuario usuario )
        {
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.Id = _usuarioDA.GetNuevoId();
            nuevoUsuario.Nombre = usuario.Nombre;
            nuevoUsuario.Password = usuario.Password;
            nuevoUsuario.IdProvincia = usuario.IdProvincia;
            nuevoUsuario.Rol = usuario.Rol;
            
            await _usuarioDA.CrearUsuario( nuevoUsuario );            
            return new JsonResult( new { success = true, responseText = "Usuario creado. Id: " + nuevoUsuario.Id.ToString() } );
        }
    }
}
