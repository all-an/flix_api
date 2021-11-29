# Flix API - Sistema Back-End de controle de filmes e espectadores.

### Sistema de controle de filmes, espectadores e visualizações.
## _"talk is cheap, show me the code" (Torvalds)_

### Utilizando Entity Framework Core, C#e e SQLite para fazer o sistema.

> Note: `Para rodar o sistema somente clone e build no Visual Studio ou VSCode` 

> dotnet run 

### Link de acesso ao Banco de Dados

[Banco de Dados SQLite](https://extendshclass.com/sqlite/e61faf1)

> https://extendsclass.com/sqlite/e61faf1

### Link de um Video breve explicando a API

[Video explicativo](https://www.youtube.com/watch?v=9TDEIPsj7lg)

> https://www.youtube.com/watch?v=9TDEIPsj7lg


Frameworks :

- .NET 3.1.415
- Entity Framework 3.1.0
- Entity Framework Core.Sqlite Version="3.1.0"
- Swagger Swashbuckle.AspNetCore Version="5.4.1"

## Características

### Inserir novos filmes;
### Ler a lista de filmes cadastrados;
### Inserir novos espectadores; 
### Ler a lista de espectadores cadastrados;
### Marcar que um espectador viu um filme específico;
### Quantos espectadores um filme teve;
#### Pelo SQL através com o Id do Filme
```sql
SELECT COUNT(*) FROM EspectadoresFilmes WHERE FilmeId = X; /* onde x é o id do filme*/
```
### Quantos filmes cada espectador viu;
#### Pelo SQL através com o Id do Espectador
```sql
SELECT COUNT(*) FROM EspectadoresFilmes WHERE EspectadorId = X;

```.
###
```
## Classe responsável por criar o objeto Espectador
```cs
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

        public IEnumerable<EspectadorCategoria> EspectadorCategorias { get; set; }

        public IEnumerable<EspectadorFilme> EspectadoresFilmes { get; set; }
    }
```

## Classe responsável por criar o objeto Filme
```cs
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
```

## Classe responsável por unir Filmes e Espectadores gerando o evento Assistir
```cs
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
```

### Controller Filmes
```cs
[ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FlixDataContext _context;
        private readonly IRepository _repo;

        public FilmeController(FlixDataContext context, IRepository repo) 
        { 
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(e => e.Id == id);
            if (filme == null) return BadRequest("Filme não encontrado");
            return Ok(filme);
        }

        //api/filme/"NomeMaiusculas"
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var filme = _context.Filmes.FirstOrDefault(e => 
                e.Nome.Contains(nome)
            );
            if (filme == null) return BadRequest("Filme não encontrado");
            return Ok(filme);
        }

        //api/filme/post
        [HttpPost]
        public IActionResult Post(Filme filme)
        {
            _repo.Add(filme);
            if(_repo.SaveChanges())
            {
                return Ok(filme);        
            }

            return BadRequest("Filme não Cadastrado");
        }

        //api/filme/put
        [HttpPut("{id}")]
        public IActionResult Put(int id, Filme filme)
        {
            var espec = _context.Filmes.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if(espec == null) return BadRequest("Filme não encontrado");
            _repo.Update(filme);
            if(_repo.SaveChanges())
            {
                return Ok(filme);        
            }

            return BadRequest("Filme não Cadastrado");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Filme filme)
        {
            var espec = _context.Filmes.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if(espec == null) return BadRequest("Filme não encontrado");
            _repo.Update(filme);
            if(_repo.SaveChanges())
            {
                return Ok(filme);        
            }

            return BadRequest("Filme não Atualizado");
        }

        //api/filme/delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filme = _context.Filmes.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if(filme == null) return BadRequest("Filme não encontrado");
            _repo.Delete(filme);
            if(_repo.SaveChanges())
            {
                return Ok("Filme Deletado");        
            }

            return BadRequest("Filme não Cadastrado");
        }
    }
```

## Como saber quantas vezes um filme foi assistido:
### Pelo SQL através do Id do Filme
```sql
SELECT COUNT(*) FROM EspectadoresFilmes WHERE FilmeId = X; /* onde x é o id do filme*/
```

## Como saber quantos filmes um espectador assistiu:
### Pelo SQL através do Id do Espectador
```sql
SELECT COUNT(*) FROM EspectadoresFilmes WHERE EspectadorId = X; /* onde x é o id do espectador*/
```


# Endpoints/Rotas:

> pode ser aberto com o Swagger

/api/espectador/byId/"id"

/api/espectador/"id"

/api/espectador/byName?nome=""&sobrenome="" //Nomes e Sobrenome com iniciais maiúsculas
/api/espectador/byname?nome=Dennis&sobrenome=Ritchie

/api/filme/

> /api/assistiu  (POST)

