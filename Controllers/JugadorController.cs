using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XFIA_API.Models;
using XFIA_API.Repositories;

namespace XFIA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly IJugador _ijugador;

        public JugadorController(IJugador ijugador)
        {
            _ijugador = ijugador;
        }

        [HttpGet("{Nombre_usuario}")]
        public async Task<IActionResult> GetInfoJugador(char Nombre_usuario)
        {
            return Ok(await _ijugador.GetInfoJugador(Nombre_usuario));
        }

        [HttpPost]
        public async Task<IActionResult> InsertJugador([FromBody] Jugador jugador)
        {
            if (jugador == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _ijugador.InsertJugador(jugador);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJugador([FromBody] Jugador jugador)
        {
            if (jugador == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ijugador.InsertJugador(jugador);

            return NoContent();
        }

        [HttpDelete("{Nombre_usuario}")]
        public async Task<IActionResult> DeleteJugador(char Nombre_usuario) 
        {
            await _ijugador.DeleteJugador(new Jugador() { Nombre_usuario = Nombre_usuario });

            return NoContent();

        }
    }
}
