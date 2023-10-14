﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using ProsegurChallengeApp.Context;
using ProsegurChallengeApp.Models;

namespace ProsegurChallengeApp.Controllers
{
    [ApiController]
    [Route( "Orden" )]
    public class OrdenController : Controller
    {
        private readonly CafeteriaDbContext _dbContext;

        public OrdenController( CafeteriaDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        private IEnumerable<SelectListItem> GetProvincias()
        {            
            var provincias = _dbContext
                        .Provincias.ToList()
                        .Select( x =>
                                new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Nombre
                                } );

            return new SelectList( provincias, "Value", "Text" );
        }

        [ApiExplorerSettings( IgnoreApi = true )]
        [Route( "Index" )]
        public IActionResult Index()
        {           
            var provincias = _dbContext.Provincias.Select
            ( x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre } ).ToList();

            provincias.Insert( 0, new SelectListItem { Value = null, Text = string.Empty } );            

            ViewBag.Provincias = provincias;

            Orden orden = new Orden();
            orden.Items = _dbContext.Items.ToList();

            return View( orden );
        }        



        //[HttpPost]
        //[Route( "CrearOrden" )]
        //public async Task<IActionResult> CrearOrden( [FromForm] Orden orden )
        //{
        //    if ( ModelState.IsValid )
        //    {                
        //        return RedirectToAction( "Index", "Home" );
        //    }

        //    return View();
        //}

        //[HttpGet]
        //[Route( "GetOrdenes" )]
        //public async Task<IActionResult> GetOrdenes()
        //{
        //    return Ok( await _dbContext.Ordenes.ToListAsync() );
        //}       
    }
}