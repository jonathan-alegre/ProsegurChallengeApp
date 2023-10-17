using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.BALClasses
{
    public class ProvinciaImpuestoBC: IProvinciaImpuestoBC
    {
        public readonly IProvinciaImpuestoDA _provinciaImpuestoDA;

        public ProvinciaImpuestoBC( IProvinciaImpuestoDA provinciaImpuestoDA )
        {
            _provinciaImpuestoDA = provinciaImpuestoDA;
        }

        public decimal GetPorcentajeImpuestoProvincia( int idProvincia )
        {
            return _provinciaImpuestoDA.GetPorcentajeImpuestoProvincia( idProvincia );
        }
    }
}
