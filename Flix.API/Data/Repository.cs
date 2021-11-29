using System.Linq;
using Flix.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flix.API.Data
{
    public class Repository : IRepository
    {
        private readonly FlixDataContext _context;

        public Repository(FlixDataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Filme[] GetAllFilmes()
        {
            throw new System.NotImplementedException();
        }

        public Filme[] GetAllFilmesByCategoriaId()
        {
            throw new System.NotImplementedException();
        }

        public Filme[] GetFilmeById()
        {
            throw new System.NotImplementedException();
        }

        public Espectador[] GetAllEspectadores()
        {
            throw new System.NotImplementedException();
        }

        public Espectador[] GetAllEspectadoresByCategoriaId()
        {
            throw new System.NotImplementedException();
        }

        public Espectador GetEspectadorById()
        {
            throw new System.NotImplementedException();
        }
    }
}