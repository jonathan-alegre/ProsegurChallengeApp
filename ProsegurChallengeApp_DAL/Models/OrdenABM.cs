namespace ProsegurChallengeApp_DAL.Models
{
    public class OrdenABM
    {   
        public string Descripcion { get; set; }

        public int IdProvincia { get; set; }                                               

        public int[] IdsItem { get; set; }

        public int IdUsuario {  get; set; } 
    }
}
