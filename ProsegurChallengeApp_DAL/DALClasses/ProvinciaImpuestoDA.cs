using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.DALClasses
{
    public class ProvinciaImpuestoDA: IProvinciaImpuestoDA
    {
        private readonly CafeteriaDbContext _dbContext;

        public ProvinciaImpuestoDA( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public decimal GetPorcentajeImpuestoProvincia( int idProvincia )
        {
            return _dbContext.ProvinciasImpuestos.First( p => p.IdProvincia == idProvincia ).PorcentajeImpuesto;
        }
    }
}
