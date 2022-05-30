using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XFIA_API.Models;
using XFIA_API.Repositories;

namespace XFIA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscuderiaController : ControllerBase
    {
        private readonly EscuderiaI _iescuderia;

        public EscuderiaController(EscuderiaI iescuderia)
        {
            _iescuderia = iescuderia;
        }

        [HttpGet("{Nombre_usuario}")]
        public async Task<IActionResult> GetInfoEscuderia(String Nombre)
        {
            return Ok(await _iescuderia.GetInfoEscuderia(Nombre));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEscuderia([FromBody] Escuderia escuderia)
        {
            if (escuderia == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _iescuderia.InsertEscuderia(escuderia);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEscuderia([FromBody] Escuderia escuderia)
        {
            if (escuderia == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iescuderia.UpdateInfoEscuderia(escuderia);

            return NoContent();
        }

        [HttpDelete("{Nombre_usuario}")]
        public async Task<IActionResult> DeleteEscuderia(Escuderia escuderia)
        {
            await _iescuderia.DeleteEscuderia(new Escuderia() { Nombre = escuderia.Nombre });

            return NoContent();

        }
    }
}
