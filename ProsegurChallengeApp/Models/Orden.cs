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

        //[ForeignKey("IdUsuario")]
        //public virtual Usuario Usuario { get; set; }    
        
        public DateTime Fecha { get; set; }

        [Required( ErrorMessage = "Debe seleccionar una Provincia." )]

        [Display( Name = "Provincia" )]
        public Guid IdProvincia { get; set; }
        
        [ForeignKey( "IdProvincia" )]
        public virtual IEnumerable<SelectListItem> Provincias { get; set; }        

        [Required( ErrorMessage = "Debe ingresar un Importe Total." )]
        [RegularExpression( @"\d", ErrorMessage = "Debe ingresar un valor decimal." )]
        public decimal ImporteTotal { get; set; }
    }
}
