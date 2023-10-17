using Microsoft.EntityFrameworkCore;
using ProsegurChallengeApp_DAL.Data;
using ProsegurChallengeApp_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProsegurChallengeApp_DAL.Models;

namespace ProsegurChallengeApp_DAL.DALClasses
{
    public class ProvinciaDA : IProvinciaDA
    {
        private readonly CafeteriaDbContext _dbContext;

        public ProvinciaDA(CafeteriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SelectListItem> GetListItemProvincias()
        {
            return _dbContext.Provincias.Select
                   (x => new SelectListItem { Value = x.Id.ToString(), Text = x.Nombre }).ToList();
        }        
    }
}
