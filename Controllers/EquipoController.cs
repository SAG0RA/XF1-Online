using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XFIA_API.Models;
using XFIA_API.Repositories;

namespace XFIA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly EquipoI _iequipo;

        public EquipoController(EquipoI iequipo)
        {
            _iequipo = iequipo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoEquipo(long id)
        {
            return Ok(await _iequipo.GetInfoEquipo(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEquipo([FromBody] Equipo equipo)
        {
            if (equipo == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _iequipo.InsertEquipo(equipo);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEquipo([FromBody] Equipo equipo)
        {
            if (equipo == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iequipo.UpdateInfoEquipo(equipo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(Equipo equipo)
        {
            await _iequipo.DeleteEquipo(new Equipo() { id = equipo.id });

            return NoContent();

        }
    }
}
