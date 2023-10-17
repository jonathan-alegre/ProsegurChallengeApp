using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_DAL.Entities;
using ProsegurChallengeApp_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsegurChallengeApp_BAL.BALClasses
{
    public class MateriaPrimaBC : IMateriaPrimaBC
    {
        public readonly IItemMateriaPrimaDA _itemMateriaPrimaDA;
        public readonly IMateriaPrimaDA _materiaPrimaDA;
        public readonly IItemMateriaPrimaBC _iItemMateriaPrimaBC;

        public MateriaPrimaBC( IItemMateriaPrimaDA itemMateriaPrimaDA, IMateriaPrimaDA materiaPrimaDA, IItemMateriaPrimaBC iItemMateriaPrimaBC )
        {
            _itemMateriaPrimaDA = itemMateriaPrimaDA;
            _materiaPrimaDA = materiaPrimaDA;
            _iItemMateriaPrimaBC = iItemMateriaPrimaBC;
        }

        public bool CantidadMateriasPrimasSuficientesParaItems( int[] idsItem )
        {
            foreach ( var idItem in idsItem )
            {
                foreach ( var materiaPrimaItem in _iItemMateriaPrimaBC.GetItemsMateriasPrimasByIdItem( idItem ).Result.ToList() )
                {
                    var materiaPrima = GetMateriaPrimaById( materiaPrimaItem.IdMateriaPrima ).Result;
                    if ( materiaPrima.Cantidad - materiaPrimaItem.CantidadMateriaPrima < 0 )
                        return false;
                }
            }

            return true;
        }

        public async Task<MateriaPrima> GetMateriaPrimaById( int idMateriaPrima )
        {
            return await Task.Run( () => _materiaPrimaDA.GetMateriaPrimaById( idMateriaPrima ) );
        }
    }
}

