using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp_DAL.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(20)]        
        public string Nombre { get; set; }
        
        [MaxLength(30)]        
        public string Password { get; set; }

        [Required]
        public int IdProvincia { get; set; }

        public string Rol { get; set; }
    }
}
