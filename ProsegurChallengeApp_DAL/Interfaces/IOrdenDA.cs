using ProsegurChallengeApp_DAL.Entities;
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
        Task<List<OrdenDataTableDto>> GetOrdenes( OrdenFiltroDto ordenFiltro );
        public int GetNuevoId();
    }
}
