using System.Collections.Generic;
using System.Linq;
using Flix.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspectadorController : ControllerBase
    {
        public List<Espectador> Espectadores = new List<Espectador>(){
            new Espectador() {
                Id = 1,
                Nome = "Allan",
                Sobrenome = "Abrahão",
                Telefone = "65498745"
            },
            new Espectador() {
                Id = 2,
                Nome = "Contratante",
                Sobrenome = "Oliveira",
                Telefone = "987465123"
            },
            new Espectador() {
                Id = 3,
                Nome = "Concorrente",
                Sobrenome = "da Silva",
                Telefone = "231654987"
            },
        };
        public EspectadorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Espectadores);
        }

        //api/espectador/"id"
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var espectador = Espectadores.FirstOrDefault(e => e.Id == id);
            if (espectador == null) return BadRequest("Espectador não foi encontrado");
            return Ok(espectador);
        }

        //api/espectador/"NomeMaiusculas"
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var espectador = Espectadores.FirstOrDefault(e => 
                e.Nome.Contains(nome) && e.Sobrenome.Contains(Sobrenome)
            );
            if (espectador == null) return BadRequest("Espectador não foi encontrado");
            return Ok(espectador);
        }

        //api/espectador/post
        [HttpPost]
        public IActionResult Post(Espectador espectador)
        {
            return Ok(espectador);
        }

        //api/espectador/put
        [HttpPut("{id}")]
        public IActionResult Put(int id, Espectador espectador)
        {
            return Ok(espectador);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Espectador espectador)
        {
            return Ok(espectador);
        }

        //api/espectador/delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
        
    }
}