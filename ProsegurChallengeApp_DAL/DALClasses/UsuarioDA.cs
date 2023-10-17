using Microsoft.AspNetCore.Mvc;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Interfaces;
using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.DALClasses
{
    public class UsuarioDA: IUsuarioDA
    {
        private readonly CafeteriaDbContext _dbContext;

        public UsuarioDA( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> UsuarioValido( string nombre, string password )
        {
            return await Task.Run( () => _dbContext.Usuarios.FirstOrDefault( u => u.Nombre == nombre && u.Password == password ) );
        }

        public async Task CrearUsuario( Usuario usuario )
        {            
            _dbContext.Usuarios.Add( usuario );
            await _dbContext.SaveChangesAsync();            
        }

        public int GetNuevoId()
        {
            return ( !_dbContext.Usuarios.Any() ? 0 : _dbContext.Usuarios.Max( u => u.Id ) ) + 1;
        }
    }
}
