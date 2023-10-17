using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp_DAL.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }        

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int TiempoRealizacion { get; set; }
    }
}
