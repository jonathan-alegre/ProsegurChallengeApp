using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class UsuarioRol
    {
        [Key]
        public int IdUsuario { get; set; }
        
        [Key]
        public int IdRol { get; set; }
    }
}
