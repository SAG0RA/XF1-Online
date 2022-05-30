using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XFIA_API.Models;
using XFIA_API.Repositories;

namespace XFIA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoPilotoController : ControllerBase
    {
        private readonly EquipoPilotoI _iequipo_Piloto;

        public EquipoPilotoController(EquipoPilotoI iequipo_Piloto)
        {
            _iequipo_Piloto = iequipo_Piloto;
        }

        [HttpGet("{Nombre_usuario}")]
        public async Task<IActionResult> GetInfoEquipo_Piloto(long equipo_id)
        {
            return Ok(await _iequipo_Piloto.GetInfoEquipo_Piloto(equipo_id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEquipo_Piloto([FromBody] Equipo_Piloto equipo_piloto)
        {
            if (equipo_piloto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _iequipo_Piloto.InsertEquipo_Piloto(equipo_piloto);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEquipo_Piloto([FromBody] Equipo_Piloto equipo_piloto)
        {
            if (equipo_piloto == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _iequipo_Piloto.UpdateInfoEquipo_Piloto(equipo_piloto);

            return NoContent();
        }

        [HttpDelete("{Nombre_usuario}")]
        public async Task<IActionResult> DeleteEquipo_Piloto(Equipo_Piloto equipo_piloto)
        {
            await _iequipo_Piloto.DeleteEquipo_Piloto(new Equipo_Piloto() { Equipo_id = equipo_piloto.Equipo_id });

            return NoContent();

        }
    }
}
