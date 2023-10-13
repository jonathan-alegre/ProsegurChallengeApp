using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class Orden
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength( 50 )]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        public Guid IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }    

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public Guid IdProvincia { get; set; }
        
        [ForeignKey( "IdProvincia" )]
        public virtual Provincia Provincia { get; set; }

        [Required]
        public decimal ImporteTotal { get; set; }
    }
}
