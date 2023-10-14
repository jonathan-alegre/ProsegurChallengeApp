using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class Orden
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength( 50 )]
        [Required( ErrorMessage = "Debe ingresar una Descripción para la Orden." )]
        public string Descripcion { get; set; }

        [Required]
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }    
        
        public DateTime Fecha { get; set; }

        [Display( Name = "Provincia" )]
        [Required( ErrorMessage = "Debe seleccionar una Provincia." )]        
        public Guid IdProvincia { get; set; }
        
        [ForeignKey( "IdProvincia" )]
        [Required]
        public virtual List<Provincia> Provincias { get; set; }

        [Display( Name = "Items" )]
        [Required( ErrorMessage = "Debe seleccionar algún Item." )]
        public Guid IdItem { get; set; }

        [ForeignKey( "IdItem" )]
        [Required]
        public virtual List<Item> Items { get; set; }

        [Required( ErrorMessage = "Debe ingresar un Importe Total." )]        
        [RegularExpression( @"^\d+(\.\d{1,2})?$", ErrorMessage = "Debe ingresar un valor decimal (de hasta 2 decimales)." )]
        public decimal ImporteTotal { get; set; }
    }
}
