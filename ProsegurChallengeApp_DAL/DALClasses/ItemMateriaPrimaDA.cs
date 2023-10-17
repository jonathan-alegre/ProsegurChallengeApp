using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Entities;
using ProsegurChallengeApp_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.DALClasses
{
    public class ItemMateriaPrimaDA: IItemMateriaPrimaDA
    {
        private readonly CafeteriaDbContext _dbContext;

        public ItemMateriaPrimaDA( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<List<ItemMateriaPrima>> GetItemsMateriasPrimasByIdItem( int idItem )
        {           
            return await Task.Run( () => _dbContext.ItemsMateriasPrimas.Where( m => m.IdItem == idItem ).ToList() );
        }
    }
}
