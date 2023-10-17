using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp_DAL.Entities
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]       
        public string Descripcion { get; set; }
        
        public int IdProvincia { get; set; }

        [ForeignKey("IdProvincia")]
        public Provincia Provincia { get; set; }
        
        public decimal Importe { get; set; }

        [Required]
        public int TiempoRealizacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        public DateTime Fecha { get; set; }                
    }
}
