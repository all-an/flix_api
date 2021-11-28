namespace Flix.API.Models
{
    public class EspectadorFilme
    {
        public EspectadorFilme() { }
        public EspectadorFilme(int espectadorId, int filmeId)
        {
            this.EspectadorId = espectadorId;
            this.FilmeId = filmeId;
        }
        public int EspectadorId { get; set; }
        public Espectador Espectador { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
    }
}