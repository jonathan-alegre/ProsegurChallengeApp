using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class UsuarioRol
    {
        [Key]
        public Guid IdUsuario { get; set; }
        
        [Key]
        public Guid IdRol { get; set; }
    }
}
