using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using ProsegurChallengeApp_DAL.OrdenDAL;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_DAL.Interfaces;
using ProsegurChallengeApp.Models;
using ProsegurChallengeApp_BAL.BALClasses;

namespace ProsegurChallengeApp_BAL.OrdenBAL
{
    public class OrdenBC : IOrdenBC
    {
        public readonly IOrdenDA _ordenDA;
        public readonly IProvinciaImpuestoBC _provinciaImpuestoBC;
        public readonly IItemBC _itemsBC;
        public readonly IMateriaPrimaBC _iMateriaPrimaBC;

        public OrdenBC( IOrdenDA ordenDA, IProvinciaImpuestoBC provinciaImpuestoBC, IItemBC itemsBC, IMateriaPrimaBC iMateriaPrimaBC )
        {
            _ordenDA = ordenDA;
            _provinciaImpuestoBC = provinciaImpuestoBC;
            _itemsBC = itemsBC;
            _iMateriaPrimaBC = iMateriaPrimaBC;
        }

        public async Task<IActionResult> CrearOrden( OrdenABM orden )
        {
            if ( !_iMateriaPrimaBC.CantidadMateriasPrimasSuficientesParaItems( orden.IdsItem ) )
            {
                return new JsonResult( new { success = false, responseText = "Hay Materias Primas insuficientes para crear la Orden." } );
            }

            int idOrden = _ordenDA.GetNuevoId();

            Orden nuevaOrden = new Orden();
            nuevaOrden.Id = idOrden;
            nuevaOrden.Descripcion = orden.Descripcion;

            List<Item> itemsOrden = _itemsBC.GetItemsByIds( orden.IdsItem ).Result.ToList();

            nuevaOrden.Importe = ImporteTotalOrden( itemsOrden, orden.IdProvincia );
            nuevaOrden.TiempoRealizacion = TiempoRealizacionOrden( itemsOrden );
            nuevaOrden.IdProvincia = orden.IdProvincia;
            nuevaOrden.IdUsuario = orden.IdUsuario;
            nuevaOrden.Fecha = DateTime.Now;

            await _ordenDA.CrearOrden( nuevaOrden, orden.IdsItem );
            return new JsonResult( new { success = true, responseText = "Orden creada. Id: " + idOrden.ToString() } );
        }

        public async Task<List<OrdenDataTable>> GetOrdenes( OrdenFiltro ordenFiltro )
        {
            return await Task.Run( () => _ordenDA.GetOrdenes( ordenFiltro ) );
        }

        public decimal ImporteTotalOrden( List<Item> items, int idProvincia )
        {
            var porcentajeImpuestoProvincia = _provinciaImpuestoBC.GetPorcentajeImpuestoProvincia( idProvincia );
            return items.Sum( i => i.Precio ) * ( 1 + decimal.Parse( porcentajeImpuestoProvincia.ToString() ) / 100 );
        }

        public int TiempoRealizacionOrden( List<Item> items )
        {
            return items.Sum( i => i.TiempoRealizacion );
        }
    }
}
