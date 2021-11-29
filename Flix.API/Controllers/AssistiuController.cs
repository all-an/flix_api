using Flix.API.Data;
using Flix.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssistiuController : ControllerBase
    {

        private readonly FlixDataContext _context;
        private readonly IRepository _repo;

        public AssistiuController(FlixDataContext context, IRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        /// <summary>
        /// Método usado para rertornar todas os Eventos de Assistir
        /// </summary>
        /// <returns></returns>
        // GET: AssistiuController
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(_context.EspectadoresFilmes);
        }

        /// <summary>
        /// Método usado para incluir evento de assistir
        /// </summary>
        /// <param name="filme"></param>
        /// <returns></returns>
        // POST: AssistiuController
        [HttpPost]
        public IActionResult Post(EspectadorFilme espectadorFilme)
        {
            _repo.Add(espectadorFilme);
            if (_repo.SaveChanges())
            {
                return Ok(espectadorFilme);
            }

            return BadRequest("Evento de Assistir não Cadastrado");
        }
    }
}
