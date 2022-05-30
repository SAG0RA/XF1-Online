using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XFIA_API.Models;
using XFIA_API.Repositories;

namespace XFIA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotoController : ControllerBase
    {
        private readonly PilotoI _ipiloto;

        public PilotoController(PilotoI ipiloto)
        {
            _ipiloto = ipiloto;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoPiloto(long id)
        {
            return Ok(await _ipiloto.GetInfoPiloto(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertPiloto([FromBody] Piloto piloto)
        {
            if (piloto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _ipiloto.InsertPiloto(piloto);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePiloto([FromBody] Piloto piloto)
        {
            if (piloto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _ipiloto.UpdateInfoPiloto(piloto);

            return NoContent();
        }

        [HttpDelete("{Nombre_usuario}")]
        public async Task<IActionResult> DeletePiloto(Piloto piloto)
        {
            await _ipiloto.DeletePiloto(new Piloto() { id = piloto.id });

            return NoContent();

        }
    }
}
