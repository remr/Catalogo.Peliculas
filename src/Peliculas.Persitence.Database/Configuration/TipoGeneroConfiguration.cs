// Peliculas.Persitence.Database
// TipoGeneroConfiguration.cs

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Peliculas.Domain;
using System.Collections.Generic;

namespace Peliculas.Persitence.Database.Configuration
{
    public class TipoGeneroConfiguration
    {
        public TipoGeneroConfiguration(EntityTypeBuilder<TipoGenero> entityBuilder)
        {
            entityBuilder.HasKey(x => x.TipoGeneroID);
            entityBuilder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
             
            var lista = new List<TipoGenero>();

            lista.Add(new TipoGenero()
            {
                TipoGeneroID = 1,
                Descripcion = "Drama"
            });

            entityBuilder.HasData(lista);
        }

    }
}