using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }        

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int TiempoRealizacion { get; set; }
    }
}
