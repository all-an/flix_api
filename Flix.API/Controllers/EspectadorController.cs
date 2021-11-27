using Microsoft.AspNetCore.Mvc;

namespace Flix.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspectadorController : ControllerBase
    {
        public EspectadorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Espectadores: Allan, Gustavo, Osmar");
        }
    }
}