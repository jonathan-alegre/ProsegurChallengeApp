using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.Interfaces
{
    public interface IProvinciaImpuestoBC
    {
        decimal GetPorcentajeImpuestoProvincia( int idProvincia );
    }
}
