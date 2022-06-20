using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XF1Api.Dtos;
using XF1Api.Models;
using XF1Api.Repositories;
using XF1Api.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace XF1Api.Controllers
{
    [ApiController]
    [Route("api/Equipo")]
    public class EquipoController: ControllerBase
    {
    

        private readonly IEquipoRepository _equipoRepository;
        public EquipoController(IEquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipo()
        {
            var equipos = await _equipoRepository.GetAll();
            return Ok(equipos);
        }
    
        [HttpGet("{Id}")]
        public async Task<ActionResult<Equipo>> GetEquipo(int Id)
        {
            var equipo = await _equipoRepository.Get(Id);
            if(equipo == null)
                return NotFound();
    
            return Ok(equipo);
        }
        [HttpPost]
        public async Task<ActionResult> CreateEquipo(CreateEquipoDto createEquipoDto)
        {
            Equipo equipo = new()
            {
                Id = createEquipoDto.Id,
                Jugador_id = createEquipoDto.Jugador_id,
                Escuderia_id = createEquipoDto.Escuderia_id,
                Nombre = createEquipoDto.Nombre
            };
            await _equipoRepository.Add(equipo);
            return Ok();
        }
    
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEquipo(int Id)
        {
            await _equipoRepository.Delete(Id);
            return Ok();
        }
    
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateEquipo(int Id, UpdateEquipoDto updateEquipoDto)
        {
            Equipo equipo = new()
            {
                Escuderia_id = updateEquipoDto.Escuderia_id,
                Nombre = updateEquipoDto.Nombre,
            };
            
    
            await _equipoRepository.Update(equipo, Id);
            return Ok();
    
        }
        
    }
}