using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1Api.Models;
using XF1Api.Data;


namespace XF1Api.Repositories
{
    public class PilotoRepository : IPilotoRepository
    {
        private readonly IXFIAOnlinedatabaseContext _context;
        public PilotoRepository(IXFIAOnlinedatabaseContext context)
        {
            _context = context;
    
        }
        public async Task Add(Piloto piloto)
        {        
            _context.PILOTO.Add(piloto);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(int Id)
        {
            var itemToRemove = await _context.PILOTO.FindAsync(Id);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.PILOTO.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Piloto> Get(int Id)
        {
            return await _context.PILOTO.FindAsync(Id);
        }
    
        public async Task<IEnumerable<Piloto>> GetAll()
        {
            return await _context.PILOTO.ToListAsync();
        }
    
        public async Task Update(Piloto piloto)
        {
            var itemToUpdate = await _context.PILOTO.FindAsync(piloto.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = piloto.Nombre;
            itemToUpdate.Precio = piloto.Precio;

            await _context.SaveChangesAsync();
    
        }

    }
}