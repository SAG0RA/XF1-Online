using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XFIA_API.Models;
using XFIA_API.Repositories;

namespace XFIA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly CarreraI _icarrera;

        public CarreraController(CarreraI icarrera)
        {
            _icarrera = icarrera;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoJugador(long id)
        {
            return Ok(await _icarrera.GetInfoCarrera(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertCarrera([FromBody] Carrera carrera)
        {
            if (carrera == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _icarrera.InsertCarrera(carrera);

            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrera([FromBody] Carrera carrera)
        {
            if (carrera == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _icarrera.UpdateInfoCarrera(carrera);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(Carrera carrera)
        {
            await _icarrera.DeleteCarrera(new Carrera() { id = carrera.id });

            return NoContent();

        }
    }
}
