using System.Linq;
using Flix.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flix.API.Data
{
    public interface IRepository
    {
         void Add<T>(T entity) where T : class; //tipo T aonde T é sempre uma classe
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         bool SaveChanges();

         //Espectadores
         Espectador[] GetAllEspectadores(); 
         Espectador[] GetAllEspectadoresByCategoriaId();
         Espectador GetEspectadorById();

         //Filmes
         Filme[] GetAllFilmes();
         Filme[] GetAllFilmesByCategoriaId();
         Filme[] GetFilmeById();

    }
}