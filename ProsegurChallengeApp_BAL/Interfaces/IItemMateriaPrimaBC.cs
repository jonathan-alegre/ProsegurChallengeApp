using ProsegurChallengeApp_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.Interfaces
{
    public interface IItemMateriaPrimaBC
    {
        Task<List<ItemMateriaPrima>> GetItemsMateriasPrimasByIdItem( int idItem );
    }
}
