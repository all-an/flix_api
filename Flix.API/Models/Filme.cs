using System.Collections.Generic;

namespace Flix.API.Models
{
    public class Filme
    {
        public Filme() { }
        public Filme(int id, string nome, int espectadorId)
        {
            this.Id = id;
            this.Nome = nome;
            this.EspectadorId = espectadorId;

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EspectadorId { get; set; }
        public Espectador Espectador { get; set; }

        public IEnumerable<EspectadorAparelho> EspectadoresAparelhos { get; set; }
    }
}