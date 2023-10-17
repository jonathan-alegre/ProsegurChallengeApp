using ProsegurChallengeApp.Models;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_DAL.Interfaces;
using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.BALClasses
{
    public class ItemBC : IItemBC
    {
        public readonly IItemDA _itemDA;

        public ItemBC( IItemDA itemDA )
        {
            _itemDA = itemDA;
        }

        public async Task<List<Item>> GetItemsByIds( int[] idsItem )
        {
            return await Task.Run( () => _itemDA.GetItemsByIds( idsItem ) );
        }
    }
}
