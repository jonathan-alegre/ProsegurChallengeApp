using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    [PrimaryKey( nameof( IdItem ), nameof( IdMateriaPrima ) )]
    public class ItemMateriaPrima
    {        
        public int IdItem { get; set; }
        
        public int IdMateriaPrima { get; set; }

        [ForeignKey( "IdMateriaPrima" )]        
        public virtual MateriaPrima MateriaPrima { get; set; }

        public decimal CantidadMateriaPrima { get; set; }        
    }
}
