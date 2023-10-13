using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp.Models
{
    public class ProvinciaImpuesto
    {
        [Required]
        public Guid IdProvincia { get; set; }

        [ForeignKey("IdProvincia")]
        public virtual Provincia Provincia { get; set; }

        [Required]
        public decimal ImporteImpuesto { get; set; }        
    }
}
