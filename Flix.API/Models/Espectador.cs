using System.Collections.Generic;

namespace Flix.API.Models
{
    public class Espectador
    {
        public Espectador() { }
        public Espectador(int id, string nome, string sobrenome, string telefone)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public IEnumerable<EspectadorCategoria> EspectadoresCategorias { get; set; }
    }
}