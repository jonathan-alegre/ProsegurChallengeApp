using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.Interfaces
{
    public interface IItemMateriaPrimaDA
    {
        Task<List<ItemMateriaPrima>> GetItemsMateriasPrimasByIdItem( int idItem );
    }
}
