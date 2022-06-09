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
    [Route("api/Piloto")]
    public class PilotoController: ControllerBase
    {
    

        private readonly IPilotoRepository _pilotoRepository;
        public PilotoController(IPilotoRepository pilotoRepository)
        {
            _pilotoRepository = pilotoRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Piloto>>> GetPiloto()
        {
            var pilotos = await _pilotoRepository.GetAll();
            return Ok(pilotos);
        }
    
        [HttpGet("{Id}")]
        public async Task<ActionResult<Piloto>> GetPiloto(int Id)
        {
            var piloto = await _pilotoRepository.Get(Id);
            if(piloto == null)
                return NotFound();
    
            return Ok(piloto);
        }
        [HttpPost]
        public async Task<ActionResult> CreatePiloto(CreatePilotoDto createPilotoDto)
        {
            Piloto piloto = new()
            {
                Id = createPilotoDto.Id,
                Nombre = createPilotoDto.Nombre,
                Precio = createPilotoDto.Precio,
                Puntaje = createPilotoDto.Puntaje
            };
            await _pilotoRepository.Add(piloto);
            return Ok();
        }
    
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeletePiloto(int Id)
        {
            await _pilotoRepository.Delete(Id);
            return Ok();
        }
    
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdatePiloto(int Id, UpdatePilotoDto updatePilotoDto)
        {
            Piloto piloto = new()
            {
                Nombre = updatePilotoDto.Nombre,
                Precio = updatePilotoDto.Precio,
                Puntaje = updatePilotoDto.Puntaje,
            };
            
    
            await _pilotoRepository.Update(piloto);
            return Ok();
    
        }
        
    }
}