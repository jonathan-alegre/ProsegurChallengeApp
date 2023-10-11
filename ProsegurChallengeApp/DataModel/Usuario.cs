using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp.DataModel
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
