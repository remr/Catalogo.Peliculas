namespace Peliculas.Repository.Models
{
    public class PeliculaDTO
    {
        public int PeliculaID { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int TipoGeneroID { get; set; }
        public TipoGeneroDTO Genero { get; set; }
    }
}