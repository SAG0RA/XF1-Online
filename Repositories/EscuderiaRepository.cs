using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1Api.Models;
using XF1Api.Data;


namespace XF1Api.Repositories
{
    public class EscuderiaRepository : IEscuderiaRepository
    {
        private readonly IXFIAOnlinedatabaseContext _context;
        public EscuderiaRepository(IXFIAOnlinedatabaseContext context)
        {
            _context = context;
    
        }
        public async Task Add(Escuderia escuderia)
        {        
            _context.ESCUDERIA.Add(escuderia);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(int Id)
        {
            var itemToRemove = await _context.ESCUDERIA.FindAsync(Id);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.ESCUDERIA.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Escuderia> Get(int Id)
        {
            return await _context.ESCUDERIA.FindAsync(Id);
        }
    
        public async Task<IEnumerable<Escuderia>> GetAll()
        {
            return await _context.ESCUDERIA.ToListAsync();
        }
    
        public async Task Update(Escuderia escuderia)
        {
            var itemToUpdate = await _context.ESCUDERIA.FindAsync(escuderia.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Precio = escuderia.Precio;

            await _context.SaveChangesAsync();
    
        }

    }
}