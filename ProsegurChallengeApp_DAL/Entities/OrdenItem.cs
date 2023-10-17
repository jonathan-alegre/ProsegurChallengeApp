using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProsegurChallengeApp_DAL.Entities
{
    [PrimaryKey(nameof(IdOrden), nameof(IdItem))]
    public class OrdenItem
    {
        public int IdOrden { get; set; }

        [ForeignKey("IdOrden")]
        public Orden Orden { get; set; }

        public int IdItem { get; set; }

        [ForeignKey("IdItem")]
        public Item Item { get; set; }
    }
}
