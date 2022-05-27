using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XFIA_API.Models;
using XFIA_API.Repositories;

namespace XFIA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampeonatoController : ControllerBase
    {
        private readonly CampeonatoI _icampeonato;

        public CampeonatoController(CampeonatoI icampeonato)
        {
            _icampeonato = icampeonato;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoJugador(char id)
        {
            return Ok(await _icampeonato.GetInfoCampeonato(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertCampeonato([FromBody] Campeonato campeonato)
        {
            if (campeonato == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _icampeonato.InsertCampeonato(campeonato);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJugador([FromBody] Campeonato campeonato)
        {
            if (campeonato == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _icampeonato.UpdateInfoCampeonato(campeonato);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampeonato(Campeonato campeonato)
        {
            await _icampeonato.DeleteCampeonato(new Campeonato() { id = campeonato.id });

            return NoContent();

        }
    }
}
