using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_DAL.DALClasses;
using ProsegurChallengeApp_DAL.Entities;
using ProsegurChallengeApp_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.BALClasses
{
    public class ItemMateriaPrimaBC: IItemMateriaPrimaBC
    {
        public readonly IItemMateriaPrimaDA _itemMateriaPrimaDA;

        public ItemMateriaPrimaBC( IItemMateriaPrimaDA itemMateriaPrimaDA )
        {            
            _itemMateriaPrimaDA = itemMateriaPrimaDA;
        }

        public async Task<List<ItemMateriaPrima>> GetItemsMateriasPrimasByIdItem( int idItem )
        {
            return await Task.Run( () => _itemMateriaPrimaDA.GetItemsMateriasPrimasByIdItem( idItem ) );
        }
    }
}
