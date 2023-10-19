using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ProsegurChallengeApp_BAL.BALClasses;
using ProsegurChallengeApp_BAL.Interfaces;
using ProsegurChallengeApp_BAL.OrdenBAL;
using ProsegurChallengeApp_DAL.DALClasses;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Models;
using ProsegurChallengeApp_DAL.OrdenDAL;
using System.Web.Helpers;

namespace ProsegurChallengeAppTests
{
    [TestClass]
    public class OrdenTests
    {
        CafeteriaDbContext cafeteriaDbContext = new CafeteriaDbContext();

        [TestMethod]
        public void CrearOrden_OrdenCreadaCorrectamente()
        {
            //Insert de datos en Base de Datos alojada en memoria
            if ( !cafeteriaDbContext.Usuarios.Any() ) //me aseguro de que haya data para no insertar de nuevo si ya hay registros insertados por la ejecucion de un testMethod anterior
                DataSeeder.SeedData( cafeteriaDbContext );

            OrdenABMDto ordenABMDto = new OrdenABMDto();

            ordenABMDto.Descripcion = "test orden";
            ordenABMDto.IdProvincia = 1;
            ordenABMDto.IdsItem = new int[] { 6, 8 };
            ordenABMDto.IdUsuario = 1;
            
            OrdenBC ordenBC = new OrdenBC( new OrdenDA( cafeteriaDbContext ),
                                           new ProvinciaImpuestoBC( new ProvinciaImpuestoDA( cafeteriaDbContext ) ),
                                           new ItemBC( new ItemDA( cafeteriaDbContext ) ),
                                           new MateriaPrimaBC( new ItemMateriaPrimaDA( cafeteriaDbContext ),
                                                               new MateriaPrimaDA( cafeteriaDbContext ),
                                                               new ItemMateriaPrimaBC( new ItemMateriaPrimaDA( cafeteriaDbContext ) )
                                                             )
                                         );

            var resultado = ordenBC.CrearOrden( ordenABMDto ).Result;
            Assert.IsNotNull( resultado );

            var jResult = JsonConvert.SerializeObject( resultado );
            var dResult = JsonConvert.DeserializeObject<Dictionary<string, object>>( jResult );
            var dResultValue = JsonConvert.DeserializeObject<Dictionary<string, object>>( dResult["Value"].ToString() );
            
            bool valorEsperado = true;            
            
            Assert.AreEqual( valorEsperado, dResultValue["success"] );
        }

        static IEnumerable<object[]> Ordenes
        {
            get
            {
                return new[]
                {
                    new object[]
                    {
                        new List<OrdenABMDto>
                        {
                            new OrdenABMDto { Descripcion = "medialuna 1", IdProvincia=1, IdsItem = new int []{7}, IdUsuario = 1 },
                            new OrdenABMDto { Descripcion = "medialuna 2", IdProvincia=1, IdsItem = new int []{7}, IdUsuario = 1 },
                            new OrdenABMDto { Descripcion = "medialuna 3", IdProvincia=1, IdsItem = new int []{7}, IdUsuario = 1 },
                            new OrdenABMDto { Descripcion = "medialuna 4", IdProvincia=1, IdsItem = new int []{7}, IdUsuario = 1 }
                        }
                    }
                };
            }
        }

        [DynamicData(nameof( Ordenes ) )]
        [TestMethod]
        public void CrearOrden_ErrorInsuficienciaMateriasPrimas( List<OrdenABMDto>  ordenesABMDto )
        {           
            //Insert de datos en Base de Datos alojada en memoria
            if ( !cafeteriaDbContext.Usuarios.Any() )//me aseguro de que haya data para no insertar de nuevo si ya hay registros insertados por la ejecucion de un testMethod anterior
                DataSeeder.SeedData( cafeteriaDbContext );

            OrdenBC ordenBC = new OrdenBC( new OrdenDA( cafeteriaDbContext ),
                                           new ProvinciaImpuestoBC( new ProvinciaImpuestoDA( cafeteriaDbContext ) ),
                                           new ItemBC( new ItemDA( cafeteriaDbContext ) ),
                                           new MateriaPrimaBC( new ItemMateriaPrimaDA( cafeteriaDbContext ),
                                                               new MateriaPrimaDA( cafeteriaDbContext ),
                                                               new ItemMateriaPrimaBC( new ItemMateriaPrimaDA( cafeteriaDbContext ) )
                                                             )
                                         );

            for ( int i = 0; i < ordenesABMDto.Count; i++ )
            {
                var resultado = ordenBC.CrearOrden( ordenesABMDto[i] ).Result;
                Assert.IsNotNull( resultado );
               
                //a la cuarta medialuna debe dar error
                if ( i == 3 )
                {
                    var jResult = JsonConvert.SerializeObject( resultado );
                    var dResult = JsonConvert.DeserializeObject<Dictionary<string, object>>( jResult );
                    var dResultValue = JsonConvert.DeserializeObject<Dictionary<string, object>>( dResult["Value"].ToString() );
                    
                    bool valorEsperado = false;                    
                    Assert.AreEqual( valorEsperado, dResultValue["success"] );
                }
            }

            

            

           
        }
    }
}