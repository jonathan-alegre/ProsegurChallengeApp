using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class DetalleOrden
    {
        [Key]
        public Guid Id { get; set; }        

        [Required]
        public Guid IdOrden { get; set; }        

        [ForeignKey( "IdOrden" )]
        public virtual Orden Orden { get; set; }

        [Required]
        public Guid IdItem { get; set; }

        [ForeignKey( "IdItem" )]
        public virtual ICollection<Item> Items { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
