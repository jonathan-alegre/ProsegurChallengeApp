using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.Models
{
    public class OrdenView
    {
        [Key]
        public int Id { get; set; }
        
        public string? Descripcion { get; set; }

        public int? IdProvincia { get; set; }
        public string Provincia { get; set; }        
        public decimal Importe { get; set; }        
        public int TiempoRealizacion { get; set; }        
        public string? Usuario { get; set; }
        public DateTime Fecha { get; set; }        
    }
}
