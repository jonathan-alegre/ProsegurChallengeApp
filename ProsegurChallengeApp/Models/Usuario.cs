using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required( ErrorMessage = "El Nombre es obligatorio." )]
        [MaxLength( 20 )]
        [StringLength( 20, ErrorMessage = "El Nombre no puede contener más de 20 caracteres" )]
        public string Nombre { get; set; }

        [Required( ErrorMessage = "La Contraseña es obligatoria." )]
        [MaxLength( 30 )]
        [StringLength( 30, ErrorMessage = "La contraseña no puede contener más de 30 caracteres" )]
        public string Password { get; set; }       

        [NotMapped]
        public bool MantenerActivo { get; set; }        
    }
}
