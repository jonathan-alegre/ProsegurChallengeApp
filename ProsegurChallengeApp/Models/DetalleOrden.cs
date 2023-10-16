using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class DetalleOrden
    {
        [Key]
        public int Id { get; set; }        

        [Required]
        public int IdOrden { get; set; }        

        [ForeignKey( "IdOrden" )]
        public  Orden Orden { get; set; }

        [Required]
        public int IdItem { get; set; }

        [ForeignKey( "IdItem" )]
        public List<Item> Items { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
