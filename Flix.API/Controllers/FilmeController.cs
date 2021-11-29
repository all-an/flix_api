using System.Linq;
using Flix.API.Data;
using Flix.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flix.API.Controllers
{
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
}