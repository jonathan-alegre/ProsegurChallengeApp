using ProsegurChallengeApp.Models;
using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.Interfaces
{
    public interface IOrdenDA
    {
        Task CrearOrden( Orden orden, int[] idsItem );
        Task<List<OrdenDataTable>> GetOrdenes( OrdenFiltro ordenFiltro );
        public int GetNuevoId();
    }
}
