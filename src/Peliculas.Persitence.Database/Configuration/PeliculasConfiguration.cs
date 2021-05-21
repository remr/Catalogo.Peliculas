// Peliculas.Persitence.Database
// PeliculasConfiguration.cs

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peliculas.Domain;

namespace Peliculas.Persitence.Database.Configuration
{
    public class PeliculasConfiguration
    {
        public PeliculasConfiguration( EntityTypeBuilder<Pelicula> entityBuilder)
        {
            entityBuilder.HasKey(x => x.PeliculaID);
            entityBuilder.Property(x => x.Clave).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);

            var lista = new List<Pelicula>();

            lista.Add( new  Pelicula()
            {
                PeliculaID = 1,
                Clave = "P001",
                Nombre = "El silencio de los inocentes",
                TipoGeneroID = 1
            });

            entityBuilder.HasData(lista);

        }
    }
}