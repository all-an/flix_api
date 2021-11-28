# Flix API - Sistema Back-End de controle de filmes e espectadores.

## _"talk is cheap, show me the code" (Torvalds)_

### Utilizando EF Core, C#, MySQL e Docker para fazer o sistema.

> Note: `Para rodar o sistema somente clone e rode no Visual Studio Code` 
> dotnet run 

Frameworks :

- .NET 3.1.415
- Entity Framework
- Blazor 

## Características

- ...
- ...


## Desenvolvimento em progresso
```cs
###
```

## Como saber quantas vezes um filme foi assistido:
### SQL
```sql
SELECT COUNT(*) FROM EspectadoresFilmes WHERE FilmeId = X; /* onde x é o id do filme*/
```

## Como saber quantos filmes um espectador assistiu:
### SQL
```sql
SELECT COUNT(*) FROM EspectadoresFilmes WHERE FilmeId = X; /* onde x é o id do espectador*/
```


# Endpoints:

/api/espectador/byId/"id"

/api/espectador/"id"

/api/espectador/byName?nome=""&sobrenome="" //Nomes e Sobrenome com iniciais maiúsculas

/api/filme/

