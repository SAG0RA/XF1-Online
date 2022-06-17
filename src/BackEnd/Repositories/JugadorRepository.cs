using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1Api.Models;
using XF1Api.Data;


namespace XF1Api.Repositories
{
    public class JugadorRepository : IJugadorRepository
    {
        private readonly IXFIAOnlinedatabaseContext _context;
        public JugadorRepository(IXFIAOnlinedatabaseContext context)
        {
            _context = context;
    
        }
        public async Task Add(Jugador jugador)
        {        
            _context.JUGADOR.Add(jugador);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(int Id)
        {
            var itemToRemove = await _context.JUGADOR.FindAsync(Id);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.JUGADOR.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Jugador> Get(int Id)
        {
            return await _context.JUGADOR.FindAsync(Id);
        }
    
        public async Task<IEnumerable<Jugador>> GetAll()
        {
            return await _context.JUGADOR.ToListAsync();
        }
    
        public async Task Update(Jugador jugador, int id)
        {
            var itemToUpdate = await _context.JUGADOR.FindAsync(id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = jugador.Nombre;
            itemToUpdate.Apellido = jugador.Apellido;
            itemToUpdate.Contrasenia = jugador.Contrasenia;

            await _context.SaveChangesAsync();
    
        }

    }
}