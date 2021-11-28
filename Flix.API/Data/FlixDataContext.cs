using System.Collections.Generic;
using Flix.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Flix.API.Data
{
    public class FlixDataContext : DbContext 
    {
        public FlixDataContext(DbContextOptions<FlixDataContext> options) : base(options)
        {
            
        }
        public DbSet<Espectador> Espectadores { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<EspectadorCategoria> EspectadorCategorias { get; set; }
        public DbSet<EspectadorFilme> EspectadoresFilmes { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EspectadorCategoria>()
                .HasKey(AD => new {AD.EspectadorId, AD.CategoriaId});

            builder.Entity<EspectadorFilme>()
                .HasKey(AD => new {AD.EspectadorId, AD.FilmeId});

            builder.Entity<Filme>()
                .HasData(new List<Filme>(){
                    new Filme(1, "Selva"),
                    new Filme(2, "Imperador"),
                    new Filme(3, "Susto"),
                    new Filme(4, "Vida"),
                    new Filme(5, "Felicidade"),
                });
            
            builder.Entity<Categoria>()
                .HasData(new List<Categoria>{
                    new Categoria(1, "Ação", 1),
                    new Categoria(2, "Biografia", 2),
                    new Categoria(3, "Horror", 3),
                    new Categoria(4, "Drama", 4),
                    new Categoria(5, "Comédia", 5)
                });
            
            builder.Entity<Espectador>()
                .HasData(new List<Espectador>(){
                    new Espectador(1, "Dennis", "Ritchie", "33225555"),
                    new Espectador(2, "Roberto", "Ierusalimschy", "3354288"),
                    new Espectador(3, "Bjarn", "Straustrup", "55668899"),
                    new Espectador(4, "Ada", "Lovelace", "6565659"),
                    new Espectador(5, "Konrad", "Zuze", "565685415"),
                    new Espectador(6, "Guido", "van Rossum", "456454545"),
                    new Espectador(7, "Anders", "Hejlsberg", "9874512")
                });

            builder.Entity<EspectadorCategoria>()
                .HasData(new List<EspectadorCategoria>() {
                    new EspectadorCategoria() {EspectadorId = 1, CategoriaId = 2 },
                    new EspectadorCategoria() {EspectadorId = 1, CategoriaId = 4 },
                    new EspectadorCategoria() {EspectadorId = 1, CategoriaId = 5 },
                    new EspectadorCategoria() {EspectadorId = 2, CategoriaId = 1 },
                    new EspectadorCategoria() {EspectadorId = 2, CategoriaId = 2 },
                    new EspectadorCategoria() {EspectadorId = 2, CategoriaId = 5 },
                    new EspectadorCategoria() {EspectadorId = 3, CategoriaId = 1 },
                    new EspectadorCategoria() {EspectadorId = 3, CategoriaId = 2 },
                    new EspectadorCategoria() {EspectadorId = 3, CategoriaId = 3 },
                    new EspectadorCategoria() {EspectadorId = 4, CategoriaId = 1 },
                    new EspectadorCategoria() {EspectadorId = 4, CategoriaId = 4 },
                    new EspectadorCategoria() {EspectadorId = 4, CategoriaId = 5 },
                    new EspectadorCategoria() {EspectadorId = 5, CategoriaId = 4 },
                    new EspectadorCategoria() {EspectadorId = 5, CategoriaId = 5 },
                    new EspectadorCategoria() {EspectadorId = 6, CategoriaId = 1 },
                    new EspectadorCategoria() {EspectadorId = 6, CategoriaId = 2 },
                    new EspectadorCategoria() {EspectadorId = 6, CategoriaId = 3 },
                    new EspectadorCategoria() {EspectadorId = 6, CategoriaId = 4 },
                    new EspectadorCategoria() {EspectadorId = 7, CategoriaId = 1 },
                    new EspectadorCategoria() {EspectadorId = 7, CategoriaId = 2 },
                    new EspectadorCategoria() {EspectadorId = 7, CategoriaId = 3 },
                    new EspectadorCategoria() {EspectadorId = 7, CategoriaId = 4 },
                    new EspectadorCategoria() {EspectadorId = 7, CategoriaId = 5 }
                });

            builder.Entity<EspectadorFilme>()
                .HasData(new List<EspectadorFilme>() {
                    new EspectadorFilme() {EspectadorId = 3, FilmeId = 3 },
                    new EspectadorFilme() {EspectadorId = 6, FilmeId = 3 },
                    new EspectadorFilme() {EspectadorId = 1, FilmeId = 1 },
                    new EspectadorFilme() {EspectadorId = 1, FilmeId = 3 },
                    new EspectadorFilme() {EspectadorId = 1, FilmeId = 5 },
                    new EspectadorFilme() {EspectadorId = 2, FilmeId = 1 },
                    new EspectadorFilme() {EspectadorId = 2, FilmeId = 2 },
                    new EspectadorFilme() {EspectadorId = 2, FilmeId = 5 },
                    new EspectadorFilme() {EspectadorId = 3, FilmeId = 1 },
                    new EspectadorFilme() {EspectadorId = 3, FilmeId = 2 },
                    new EspectadorFilme() {EspectadorId = 4, FilmeId = 1 },
                    new EspectadorFilme() {EspectadorId = 4, FilmeId = 4 },
                    new EspectadorFilme() {EspectadorId = 5, FilmeId = 4 },
                    new EspectadorFilme() {EspectadorId = 5, FilmeId = 5 },
                    new EspectadorFilme() {EspectadorId = 6, FilmeId = 1 },
                    new EspectadorFilme() {EspectadorId = 6, FilmeId = 2 },
                    new EspectadorFilme() {EspectadorId = 6, FilmeId = 4 },
                    new EspectadorFilme() {EspectadorId = 7, FilmeId = 1 },
                    new EspectadorFilme() {EspectadorId = 7, FilmeId = 2 },
                    new EspectadorFilme() {EspectadorId = 7, FilmeId = 3 },
                    new EspectadorFilme() {EspectadorId = 7, FilmeId = 4 },
                    new EspectadorFilme() {EspectadorId = 7, FilmeId = 5 }
                });

        }
    }
}