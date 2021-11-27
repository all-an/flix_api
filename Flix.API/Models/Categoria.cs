using System.Collections.Generic;

namespace Flix.API.Models
{
    public class Categoria
    {
        public Categoria() { }

        public Categoria(int id, string nome, int filmeId)
        {
            this.Id = id;
            this.Nome = nome;
            this.FilmeId = filmeId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public IEnumerable<EspectadorCategoria> EspectadoresCategorias { get; set; } 

    }
}