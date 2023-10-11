﻿using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string Nombre { get; set; }

        [MaxLength( 50 )]
        public string Password { get; set; }   
    }
}
