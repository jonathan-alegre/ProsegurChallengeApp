using ProsegurChallengeApp_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProsegurChallengeApp_DAL.Interfaces
{
    public interface IProvinciaDA   
    {
        List<SelectListItem> GetListItemProvincias();
    }
}
