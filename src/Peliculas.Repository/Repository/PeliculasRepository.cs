
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Peliculas.Domain;
using Peliculas.Persitence.Database;
using Peliculas.Repository.Contracts;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Peliculas.Repository.Repository
{
    public class PeliculasRepository : IPeliculaRepository
    {
        private readonly ApplicationDbContext _context;

        public PeliculasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Pelicula> FindAll()
        {
            var result = _context.Peliculas
                .Include(x => x.Genero)
                .AsNoTracking();

            return result.ToList();
            
        }

        public Pelicula FindById(int id)
        {
            var norma = _context.Peliculas
                .Include(r => r.Genero)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PeliculaID == id);

            return norma.Result;
        }

        public bool IsExists(int id)
        {
            var exists = _context.Peliculas.Any(x => x.PeliculaID == id);
            return exists;
        }

        public bool Create(Pelicula entity)
        {
            _context.Peliculas.Add(entity);
            return Save();
        }

        public bool Update(Pelicula entity)
        {
            _context.Peliculas.Update(entity);
            return Save();
        }

        public bool Delete(Pelicula entity)
        {
            _context.Peliculas.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0;
        }
    }
}