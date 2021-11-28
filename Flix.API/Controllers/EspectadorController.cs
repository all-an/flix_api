using System.Collections.Generic;
using System.Linq;
using Flix.API.Data;
using Flix.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspectadorController : ControllerBase
    {
        private readonly FlixDataContext _context;
        public readonly IRepository _repo;

        public EspectadorController(FlixDataContext context, IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Espectadores);
        }

        [HttpGet("pegaResposta")]
        public IActionResult pegaResposta()
        {
            return Ok(_repo.pegaResposta());
        }

        //api/espectador/"id"
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var espectador = _context.Espectadores.FirstOrDefault(e => e.Id == id);
            if (espectador == null) return BadRequest("Espectador não encontrado");
            return Ok(espectador);
        }

        //api/espectador/"NomeMaiusculas"
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var espectador = _context.Espectadores.FirstOrDefault(e =>
                e.Nome.Contains(nome) && e.Sobrenome.Contains(Sobrenome)
            );
            if (espectador == null) return BadRequest("Espectador não encontrado");
            return Ok(espectador);
        }

        //api/espectador/post
        [HttpPost]
        public IActionResult Post(Espectador espectador)
        {
            _context.Add(espectador);
            _context.SaveChanges();
            return Ok(espectador);
        }

        //api/espectador/put
        [HttpPut("{id}")]
        public IActionResult Put(int id, Espectador espectador)
        {
            var espec = _context.Espectadores.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (espec == null) return BadRequest("Espectador não encontrado");
            _context.Update(espectador);
            _context.SaveChanges();
            return Ok(espectador);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Espectador espectador)
        {
            var espec = _context.Espectadores.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (espec == null) return BadRequest("Espectador não encontrado");
            _context.Update(espectador);
            _context.SaveChanges();
            return Ok(espectador);
        }

        //api/espectador/delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var espectador = _context.Espectadores.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (espectador == null) return BadRequest("Espectador não encontrado");
            _context.Remove(espectador);
            _context.SaveChanges();
            return Ok();
        }

    }
}