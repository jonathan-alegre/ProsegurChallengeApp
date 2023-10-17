namespace ProsegurChallengeApp_DAL.Models
{
    public class OrdenDataTableDto
    {        
        public int Id { get; set; }

        public string? Descripcion { get; set; }        
        
        public string Provincia { get; set; }
        
        public decimal Importe { get; set; }
        
        public int TiempoRealizacion { get; set; }
        
        public string? Usuario { get; set; }
        
        public DateTime Fecha { get; set; }
    }
}
