namespace Flix.API.Models
{
    public class EspectadorCategoria
    {
        public EspectadorCategoria() { }
        public EspectadorCategoria(int espectadorId, int categoriaId)
        {
            this.EspectadorId = espectadorId;
            this.CategoriaId = categoriaId;
        }
        public int EspectadorId { get; set; }
        public Espectador Espectador { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}