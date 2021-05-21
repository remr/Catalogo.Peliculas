// Peliculas.Repository
// Class1.cs

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Peliculas.Domain;
using Peliculas.Persitence.Database;
using Peliculas.Repository.Contracts;

namespace Peliculas.Repository.Repository
{
    public class TipoGeneroRepository : ITipoGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoGeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<TipoGenero> FindAll()
        {
            var result = _context.TipoGeneros
                .AsNoTracking();

            return result.ToList();
        }

        public TipoGenero FindById(int id)
        {
            var gen = _context.TipoGeneros
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TipoGeneroID == id);
            return gen.Result;
        }

        public bool IsExists(int id)
        {
            var exists = _context.TipoGeneros.Any(x => x.TipoGeneroID == id);
            return exists;
        }

        public bool Create(TipoGenero entity)
        {
            _context.TipoGeneros.Add(entity);
            return Save();
        }

        public bool Update(TipoGenero entity)
        {
            _context.TipoGeneros.Update(entity);
            return Save();
        }

        public bool Delete(TipoGenero entity)
        {
            _context.TipoGeneros.Remove(entity);
            return Save();
        }

        public bool Save()
        {
            var changes = _context.SaveChanges();
            return changes > 0;
        }
    }
}