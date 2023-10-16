using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }

        [MaxLength( 50 )]
        [Required( ErrorMessage = "Debe ingresar una Descripción." )]
        public string Descripcion { get; set; }

        [Display( Name = "Provincia" )]
        [Required( ErrorMessage = "Debe seleccionar una Provincia." )]
        public int IdProvincia { get; set; }

        [ForeignKey( "IdProvincia" )]
        public Provincia Provincia { get; set; }

        [RegularExpression( @"^\d+(\.\d{1,2})?$", ErrorMessage = "Debe ingresar un valor decimal (de hasta 2 decimales)." )]
        public decimal Importe { get; set; }

        [Required]
        public int TiempoRealizacion{ get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }    
        
        public DateTime Fecha { get; set; }                
        
        [Display( Name = "Items" )]
        [ForeignKey( "IdItem" )]
        [Required( ErrorMessage = "Debe seleccionar algún Item." )]
        public IEnumerable<Item> Items { get; set; }                
    }
}
