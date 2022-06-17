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
    [Route("api/Jugador")]
    public class JugadorController: ControllerBase
    {
    

        private readonly IJugadorRepository _jugadorRepository;
        public JugadorController(IJugadorRepository jugadorRepository)
        {
            _jugadorRepository = jugadorRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetJugador()
        {
            var jugadors = await _jugadorRepository.GetAll();
            return Ok(jugadors);
        }
    
        [HttpGet("{Id}")]
        public async Task<ActionResult<Jugador>> GetJugador(int Id)
        {
            var jugador = await _jugadorRepository.Get(Id);
            if(jugador == null)
                return NotFound();
    
            return Ok(jugador);
        }
        [HttpPost]
        public async Task<ActionResult> CreateJugador(CreateJugadorDto createJugadorDto)
        {
            Jugador jugador = new()
            {
                Id = createJugadorDto.Id,
                Nombre = createJugadorDto.Nombre,
                Nombre_usuario = createJugadorDto.Nombre_usuario,
                Apellido = createJugadorDto.Apellido,
                Correo = createJugadorDto.Correo,
                Rango_edad = createJugadorDto.Rango_edad,
                Pais = createJugadorDto.Pais,
                Contrasenia = createJugadorDto.Contrasenia,
            };
            await _jugadorRepository.Add(jugador);
            return Ok();
        }
    
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteJugador(int Id)
        {
            await _jugadorRepository.Delete(Id);
            return Ok();
        }
    
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateJugador(int Id, UpdateJugadorDto updateJugadorDto)
        {
            Jugador jugador = new()
            {
                Nombre = updateJugadorDto.Nombre,
                Apellido = updateJugadorDto.Apellido,
                Contrasenia = updateJugadorDto.Contrasenia,
            };
            
    
            await _jugadorRepository.Update(jugador, Id);
            return Ok();
    
        }
        
    }
}