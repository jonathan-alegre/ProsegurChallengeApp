using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="El Nombre es obligatorio.")]        
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Contraseña es obligatoria.")]
        public string Password { get; set; }
    }
}
