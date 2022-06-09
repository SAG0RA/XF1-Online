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
    [Route("api/Carrera")]
    public class CarreraController: ControllerBase
    {
    

        private readonly ICarreraRepository _carreraRepository;
        public CarreraController(ICarreraRepository carreraRepository)
        {
            _carreraRepository = carreraRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarrera()
        {
            var carreras = await _carreraRepository.GetAll();
            return Ok(carreras);
        }
    
        [HttpGet("{Id}")]
        public async Task<ActionResult<Carrera>> GetCarrera(string Id)
        {
            var carrera = await _carreraRepository.Get(Id);
            if(carrera == null)
                return NotFound();
    
            return Ok(carrera);
        }
        [HttpPost]
        public async Task<ActionResult> CreateCarrera(CreateCarreraDto createCarreraDto)
        {
            Carrera carrera = new()
            {
                Id = createCarreraDto.Id,
                Nombre = createCarreraDto.Nombre,
                Nombre_pista = createCarreraDto.Nombre_pista,
                Pais = createCarreraDto.Pais,
                Fecha_inicio = createCarreraDto.Fecha_inicio,
                Fecha_fin = createCarreraDto.Fecha_fin,
                Estado = createCarreraDto.Estado,
                Id_Campeonato = createCarreraDto.Id_Campeonato,
            };
            await _carreraRepository.Add(carrera);
            return Ok();
        }
    
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCarrera(string Id)
        {
            await _carreraRepository.Delete(Id);
            return Ok();
        }
    
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateCarrera(string Id, UpdateCarreraDto updateCarreraDto)
        {
            Carrera carrera = new()
            {
                Nombre = updateCarreraDto.Nombre,
                Nombre_pista = updateCarreraDto.Nombre_pista,
                Fecha_inicio = updateCarreraDto.Fecha_inicio,
                Fecha_fin = updateCarreraDto.Fecha_fin,
                Estado = updateCarreraDto.Estado
            };
            
    
            await _carreraRepository.Update(carrera);
            return Ok();
    
        }
        
    }
}