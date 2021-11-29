namespace Flix.API.Models
{
    public class EspectadorFilme
    {

        public EspectadorFilme() { }
        public EspectadorFilme(int espectadorId, int filmeId)
        {
            Id++;
            this.EspectadorId = espectadorId;
            this.FilmeId = filmeId;
     
        }

        public static int Id { get; set; }
        public int EspectadorId { get; set; }
        public int FilmeId { get; set; }
    }
}