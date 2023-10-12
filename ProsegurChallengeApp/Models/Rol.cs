using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.Models
{
    public class Rol
    {
        [Key]
        public Guid Id { get; set; }
        
        [MaxLength( 20 )]        
        public string Descripcion { get; set; }                
    }
}
