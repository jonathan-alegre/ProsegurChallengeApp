using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.Models
{
    public class OrdenFiltro
    {   
        public string? Descripcion { get; set; }        
        public int? IdProvincia { get; set; }               
        public string? Usuario { get; set; }        
    }
}
