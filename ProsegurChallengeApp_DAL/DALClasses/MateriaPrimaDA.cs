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
    public class MateriaPrimaDA: IMateriaPrimaDA
    {
        private readonly CafeteriaDbContext _dbContext;

        public MateriaPrimaDA( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<MateriaPrima> GetMateriaPrimaById( int idMateriaPrima )
        {
            return await Task.Run( () => _dbContext.MateriasPrimas.First( m => m.Id == idMateriaPrima ) );
        }
    }
}
