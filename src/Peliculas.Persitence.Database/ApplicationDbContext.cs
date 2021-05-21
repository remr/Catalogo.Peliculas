using System;
using Microsoft.EntityFrameworkCore;
using Peliculas.Domain;
using Peliculas.Persitence.Database.Configuration;

namespace Peliculas.Persitence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Peliculas");

            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new PeliculasConfiguration(modelBuilder.Entity<Pelicula>());
            new TipoGeneroConfiguration(modelBuilder.Entity<TipoGenero>());
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<TipoGenero> TipoGeneros { get; set; }


    }
}
