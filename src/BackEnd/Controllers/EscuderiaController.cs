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
    [Route("api/Escuderia")]
    public class EscuderiaController: ControllerBase
    {
    

        private readonly IEscuderiaRepository _escuderiaRepository;
        public EscuderiaController(IEscuderiaRepository escuderiaRepository)
        {
            _escuderiaRepository = escuderiaRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Escuderia>>> GetEscuderia()
        {
            var escuderias = await _escuderiaRepository.GetAll();
            return Ok(escuderias);
        }
    
        [HttpGet("{Id}")]
        public async Task<ActionResult<Escuderia>> GetEscuderia(int Id)
        {
            var escuderia = await _escuderiaRepository.Get(Id);
            if(escuderia == null)
                return NotFound();
    
            return Ok(escuderia);
        }
        [HttpPost]
        public async Task<ActionResult> CreateEscuderia(CreateEscuderiaDto createEscuderiaDto)
        {
            Escuderia escuderia = new()
            {
                Id = createEscuderiaDto.Id,
                Nombre = createEscuderiaDto.Nombre,
                Precio = createEscuderiaDto.Precio,
                Puntaje = createEscuderiaDto.Puntaje
            };
            await _escuderiaRepository.Add(escuderia);
            return Ok();
        }
    
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteEscuderia(int Id)
        {
            await _escuderiaRepository.Delete(Id);
            return Ok();
        }
    
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateEscuderia(int Id, UpdateEscuderiaDto updateEscuderiaDto)
        {
            Escuderia escuderia = new()
            {
                Precio = updateEscuderiaDto.Precio,
                Puntaje = updateEscuderiaDto.Puntaje
            };
            
    
            await _escuderiaRepository.Update(escuderia, Id);
            return Ok();
    
        }
        
    }
}