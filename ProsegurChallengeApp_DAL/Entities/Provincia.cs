using System.ComponentModel.DataAnnotations;

namespace ProsegurChallengeApp_DAL.Entities
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}
