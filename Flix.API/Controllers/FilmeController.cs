using Microsoft.AspNetCore.Mvc;

namespace Flix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        public FilmeController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Filmes: A Procura da Felicidade (Will Smith), Contratei o Allan e Acertei, Indiquei o Allan e ele Agradeceu pra Sempre");
        }
    }
}