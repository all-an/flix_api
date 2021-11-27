using System.Collections.Generic;

namespace Flix.API.Models
{
    public class Filme
    {
        public Filme() { }
        public Filme(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; }
    }
}