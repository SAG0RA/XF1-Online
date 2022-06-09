using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1Api.Models;
using XF1Api.Data;


namespace XF1Api.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {
        private readonly IXFIAOnlinedatabaseContext _context;
        public EquipoRepository(IXFIAOnlinedatabaseContext context)
        {
            _context = context;
    
        }
        public async Task Add(Equipo equipo)
        {        
            _context.EQUIPO.Add(equipo);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(int Id)
        {
            var itemToRemove = await _context.EQUIPO.FindAsync(Id);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.EQUIPO.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Equipo> Get(int Id)
        {
            return await _context.EQUIPO.FindAsync(Id);
        }
    
        public async Task<IEnumerable<Equipo>> GetAll()
        {
            return await _context.EQUIPO.ToListAsync();
        }
    
        public async Task Update(Equipo equipo)
        {
            var itemToUpdate = await _context.EQUIPO.FindAsync(equipo.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Escuderia_id = equipo.Escuderia_id;

            await _context.SaveChangesAsync();
    
        }

    }
}