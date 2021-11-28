using Flix.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flix.API.Data
{
    public class FlixDataContext : DbContext 
    {
        public FlixDataContext(DbContextOptions<FlixDataContext> options) : base(options)
        {
            
        }
        public DbSet<Espectador> Espectador { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Categoria> Categoriasw { get; set; }
        public DbSet<EspectadorCategoria> EspectadorCategorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EspectadorCategoria>()
                .HasKey(AD => new {AD.EspectadorId, AD.CategoriaId});

        }
    }
}