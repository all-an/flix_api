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
        public FilmeController(FlixDataContext context) 
        { 
            _context = context;
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
            if (filme == null) return BadRequest("filme não encontrado");
            return Ok(filme);
        }

        //api/filme/"NomeMaiusculas"
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var filme = _context.Filmes.FirstOrDefault(e => 
                e.Nome.Contains(nome)
            );
            if (filme == null) return BadRequest("filme não encontrado");
            return Ok(filme);
        }

        //api/filme/post
        [HttpPost]
        public IActionResult Post(Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();
            return Ok(filme);
        }

        //api/filme/put
        [HttpPut("{id}")]
        public IActionResult Put(int id, Filme filme)
        {
            var espec = _context.Filmes.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if(espec == null) return BadRequest("Filme não encontrado");
            _context.Update(filme);
            _context.SaveChanges();
            return Ok(filme);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Filme filme)
        {
            var espec = _context.Filmes.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if(espec == null) return BadRequest("Filme não encontrado");
            _context.Update(filme);
            _context.SaveChanges();
            return Ok(filme);
        }

        //api/filme/delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var filme = _context.Filmes.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if(filme == null) return BadRequest("Filme não encontrado");
            _context.Remove(filme);
            _context.SaveChanges();
            return Ok();
        }
    }
}