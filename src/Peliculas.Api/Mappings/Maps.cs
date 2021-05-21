// Peliculas.Api
// Maps.cs

using AutoMapper;
using Peliculas.Domain;
using Peliculas.Repository.Models;

namespace Peliculas.Api.Mappings
{
    public class Maps : Profile
    {
        public Maps ( )
        {
            /* source-> destination*/
            CreateMap<Pelicula, PeliculaDTO> ( ).ReverseMap ( );
            CreateMap<TipoGenero, TipoGeneroDTO> ( ).ReverseMap ( );
        }
    }
}