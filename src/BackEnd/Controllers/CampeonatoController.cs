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
    [Route("api/Campeonato")]
    public class CampeonatoController: ControllerBase
    {
    

        private readonly ICampeonatoRepository _campeonatoRepository;
        public CampeonatoController(ICampeonatoRepository campeonatoRepository)
        {
            _campeonatoRepository = campeonatoRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campeonato>>> GetCampeonato()
        {
            var campeonatos = await _campeonatoRepository.GetAll();
            return Ok(campeonatos);
        }
    
        [HttpGet("{Id}")]
        public async Task<ActionResult<Campeonato>> GetCampeonato(string Id)
        {
            var campeonato = await _campeonatoRepository.Get(Id);
            if(campeonato == null)
                return NotFound();
    
            return Ok(campeonato);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCampeonato(CreateCampeonatoDto createCampeonatoDto)
        {
            Campeonato campeonato = new()
            {
                Id = createCampeonatoDto.Id,
                Nombre = createCampeonatoDto.Nombre,
                Fecha_inicio = createCampeonatoDto.Fecha_inicio,
                Fecha_fin = createCampeonatoDto.Fecha_fin,
                Descripcion_reglas = createCampeonatoDto.Descripcion_reglas
            };
            await _campeonatoRepository.Add(campeonato);
            return Ok();
        }
    
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCampeonato(string Id)
        {
            await _campeonatoRepository.Delete(Id);
            return Ok();
        }
    
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateCampeonato(string Id, UpdateCampeonatoDto updateCampeonatoDto)
        {
            Campeonato campeonato = new()
            {
                Nombre = updateCampeonatoDto.Nombre,
                Fecha_inicio = updateCampeonatoDto.Fecha_inicio,
                Fecha_fin = updateCampeonatoDto.Fecha_fin,
                Descripcion_reglas = updateCampeonatoDto.Descripcion_reglas
            };
            
    
            await _campeonatoRepository.Update(campeonato, Id);
            return Ok();
    
        }
        
    }
}