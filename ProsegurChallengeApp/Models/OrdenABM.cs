using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class OrdenABM
    {   
        public string Descripcion { get; set; }

        public int IdProvincia { get; set; }                                               

        public int[] IdsItem { get; set; }
    }
}
