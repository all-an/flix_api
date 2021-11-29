using System.Collections.Generic;
using System.Linq;
using Flix.API.Data;
using Flix.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flix.API.Controllers
{    
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EspectadorController : ControllerBase
    {
        private readonly FlixDataContext _context;
        public readonly IRepository _repo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="repo"></param>
        public EspectadorController(FlixDataContext context, IRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        /// <summary>
        /// Método usado para retornar todos os espectadores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Espectadores);
        }

        /// <summary>
        /// Método usado para retornar cada espectador por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //api/espectador/"id"
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var espectador = _context.Espectadores.FirstOrDefault(e => e.Id == id);
            if (espectador == null) return BadRequest("Espectador não encontrado");
            return Ok(espectador);
        }

        /// <summary>
        /// Método usado para retornar cada espectador por nome.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="Sobrenome"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método usado para cadastrar espectador.
        /// </summary>
        /// <param name="espectador"></param>
        /// <returns></returns>
        //api/espectador/post
        [HttpPost]
        public IActionResult Post(Espectador espectador)
        {
            _repo.Add(espectador);
            if(_repo.SaveChanges())
            {
                return Ok(espectador);        
            }

            return BadRequest("Espectador não cadastrado");
        }

        /// <summary>
        /// Método usado para atualizar dado de espectador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="espectador"></param>
        /// <returns></returns>
        //api/espectador/put
        [HttpPut("{id}")]
        public IActionResult Put(int id, Espectador espectador)
        {
            var espec = _context.Espectadores.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (espec == null) return BadRequest("Espectador não encontrado");
            _repo.Update(espectador);
            if(_repo.SaveChanges())
            {
                return Ok(espectador);        
            }

            return BadRequest("Espectador não atualizado");
        }

        /// <summary>
        /// Método usado para atualizar uma parte dos dados de um espectador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="espectador"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Espectador espectador)
        {
            var espec = _context.Espectadores.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (espec == null) return BadRequest("Espectador não encontrado");
            _repo.Update(espectador);
            if(_repo.SaveChanges())
            {
                return Ok(espectador);        
            }

            return BadRequest("Espectador não Atualizado");
        }

        /// <summary>
        /// Método usado para remover espectador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //api/espectador/delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var espectador = _context.Espectadores.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (espectador == null) return BadRequest("Espectador não encontrado");
            _repo.Delete(espectador);
            if(_repo.SaveChanges())
            {
                return Ok("Espectador Deletado");        
            }

            return BadRequest("Espectador não Deletado");
        }

    }
}