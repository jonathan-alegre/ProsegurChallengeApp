﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProsegurChallengeApp_DAL.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp_DAL.Models
{
    public class UsuarioABMViewModel
    {        
        [Required( ErrorMessage = "El Nombre es obligatorio." )]
        [MaxLength( 20 )]
        [StringLength( 20, ErrorMessage = "El Nombre no puede contener más de 20 caracteres" )]
        public string Nombre { get; set; }

        [Required( ErrorMessage = "La Contraseña es obligatoria." )]
        [MaxLength( 30 )]
        [StringLength( 30, ErrorMessage = "La contraseña no puede contener más de 30 caracteres" )]
        public string Password { get; set; }

        [Required( ErrorMessage = "La Provincia es obligatoria." )]
        [Display( Name = "Provincia" )]
        public int IdProvincia { get; set; }        

        [NotMapped]
        [Compare( "Password", ErrorMessage = "Las Contraseñas ingresadas deben ser iguales" )]
        public string ConfirmaPassword { get; set; }
    }
}
