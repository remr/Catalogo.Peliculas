

using System;

namespace Peliculas.Domain
{
    public class Pelicula
    {
        public int PeliculaID { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int TipoGeneroID { get; set; }
        public TipoGenero Genero { get; set; }
    }
}