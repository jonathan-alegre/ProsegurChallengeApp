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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProsegurChallengeApp_BAL.BALClasses
{
    public class ProvinciaBC : IProvinciaBC
    {        
        public readonly IProvinciaDA _provinciaDA;

        public ProvinciaBC( IProvinciaDA provinciaDA )
        {            
            _provinciaDA = provinciaDA;
        }

        public List<SelectListItem> GetListItemProvincias()
        {
            return _provinciaDA.GetListItemProvincias();
        }
    }
}
