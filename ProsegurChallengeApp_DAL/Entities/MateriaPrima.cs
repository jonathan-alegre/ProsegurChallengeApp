﻿using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp_DAL.Entities
{
    public class MateriaPrima
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public decimal Cantidad { get; set; }
    }
}
