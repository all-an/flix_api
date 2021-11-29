namespace Flix.API.Models
{
    public class EspectadorFilme
    {

        public EspectadorFilme() { }
        public EspectadorFilme(int id, int espectadorId, int filmeId)
        {
            this.Id = id;
            this.EspectadorId = espectadorId;
            this.FilmeId = filmeId;
        }

        public int Id { get; set; }
        public int EspectadorId { get; set; }
        public Espectador Espectador { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
    }
}