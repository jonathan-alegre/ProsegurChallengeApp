using ProsegurChallengeApp_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_DAL.Interfaces
{
    public interface IMateriaPrimaDA
    {
        Task<MateriaPrima> GetMateriaPrimaById( int idMateriaPrima );
    }
}
