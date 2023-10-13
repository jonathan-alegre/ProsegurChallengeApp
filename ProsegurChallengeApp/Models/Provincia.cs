using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.Models
{
    public class Provincia
    {
        [Key]
        public Guid Id { get; set; }        

        [Required]
        public string Nombre { get; set; }        
    }
}
