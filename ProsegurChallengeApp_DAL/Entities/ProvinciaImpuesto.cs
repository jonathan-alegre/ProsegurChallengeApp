﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp_DAL.Entities
{
    public class ProvinciaImpuesto
    {
        [Key]
        [Required]
        public int IdProvincia { get; set; }

        [ForeignKey("IdProvincia")]
        public Provincia Provincia { get; set; }

        [Required]
        public decimal PorcentajeImpuesto { get; set; }
    }
}
