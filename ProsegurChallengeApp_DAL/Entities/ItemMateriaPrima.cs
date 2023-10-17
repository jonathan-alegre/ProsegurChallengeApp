using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp_DAL.Entities
{
    [PrimaryKey(nameof(IdItem), nameof(IdMateriaPrima))]
    public class ItemMateriaPrima
    {
        public int IdItem { get; set; }

        public int IdMateriaPrima { get; set; }

        [ForeignKey("IdMateriaPrima")]
        public MateriaPrima MateriaPrima { get; set; }

        public decimal CantidadMateriaPrima { get; set; }
    }
}
