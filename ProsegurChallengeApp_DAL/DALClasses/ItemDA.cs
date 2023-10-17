using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Entities;
using ProsegurChallengeApp_DAL.Interfaces;
using ProsegurChallengeApp_DAL.OrdenDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.DALClasses
{
    public class ItemDA: IItemDA
    {
        private readonly CafeteriaDbContext _dbContext;

        public ItemDA( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> GetItemsByIds( int[] idsItem )
        {
            return await Task.Run( () => _dbContext.Items.Where( i => idsItem.ToList().Contains( i.Id ) ).ToList() );
        }
    }
}
