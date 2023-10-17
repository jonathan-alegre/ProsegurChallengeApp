using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProsegurChallengeApp_DAL.Entities;
using ProsegurChallengeApp_DAL.Models;

namespace ProsegurChallengeApp_DAL.OrdenDAL
{
    public class OrdenDA: IOrdenDA
    {
        private readonly CafeteriaDbContext _dbContext;

        public OrdenDA( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }        

        public async Task CrearOrden( Orden orden, int[] idsItem )
        {
            foreach ( var idItem in idsItem )
            {
                OrdenItem ordenItem = new OrdenItem() { IdOrden = orden.Id, IdItem = idItem };
                _dbContext.OrdenesItems.Add( ordenItem );

                foreach ( var materiaPrimaItem in _dbContext.ItemsMateriasPrimas.Where( m => m.IdItem == idItem ).ToList() )
                {
                    var materiaPrima = _dbContext.MateriasPrimas.First( m => m.Id == materiaPrimaItem.IdMateriaPrima );                    
                    materiaPrima.Cantidad -= materiaPrimaItem.CantidadMateriaPrima;                    
                }
            }

            _dbContext.Ordenes.Add( orden );
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<OrdenDataTableDto>> GetOrdenes( OrdenFiltroDto ordenFiltro )
        {
            List<OrdenDataTableDto> ordenesDT = new List<OrdenDataTableDto>();

            List<Orden> ordenesFiltradas = _dbContext.Ordenes.Where(
                                                o => ( string.IsNullOrEmpty( ordenFiltro.Descripcion ) || o.Descripcion.ToUpper().Contains( ordenFiltro.Descripcion.ToUpper() ) ) &&
                                                     ( ordenFiltro.IdProvincia == null || o.IdProvincia == ordenFiltro.IdProvincia ) &&
                                                     ( string.IsNullOrEmpty( ordenFiltro.Usuario ) || _dbContext.Usuarios.Where( u => u.Nombre.ToUpper().Contains( ordenFiltro.Usuario.ToUpper() ) ).Select( u => u.Id ).Contains( o.IdUsuario ) )
                                           ).ToList();

            foreach ( var orden in ordenesFiltradas )
            {
                OrdenDataTableDto ordenView = new OrdenDataTableDto();
                ordenView.Id = orden.Id;
                ordenView.Descripcion = orden.Descripcion;
                ordenView.Provincia = _dbContext.Provincias.First( p => p.Id == orden.IdProvincia ).Nombre;
                ordenView.Importe = orden.Importe;
                ordenView.TiempoRealizacion = orden.TiempoRealizacion;
                ordenView.Usuario = _dbContext.Usuarios.First( u => u.Id == orden.IdUsuario ).Nombre;
                ordenView.Fecha = orden.Fecha;

                ordenesDT.Add( ordenView );
            }

            return await Task.Run( () => ordenesDT );
        }

        public int GetNuevoId()
        {
            return ( !_dbContext.Ordenes.Any() ? 0 : _dbContext.Ordenes.Max( o => o.Id ) ) + 1;
        }
    }
}
