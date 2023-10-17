using Microsoft.AspNetCore.Mvc;
using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.Interfaces
{
    public interface IOrdenBC
    {
        Task<IActionResult> CrearOrden( OrdenABMDto orden );
        Task<List<OrdenDataTableDto>> GetOrdenes( OrdenFiltroDto ordenFiltro );
    }
}
