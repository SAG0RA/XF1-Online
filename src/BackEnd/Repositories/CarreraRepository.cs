using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1Api.Models;
using XF1Api.Data;


namespace XF1Api.Repositories
{
    public class CarreraRepository : ICarreraRepository
    {
        private readonly IXFIAOnlinedatabaseContext _context;
        public CarreraRepository(IXFIAOnlinedatabaseContext context)
        {
            _context = context;
    
        }
        public async Task Add(Carrera carrera)
        {        
            _context.CARRERA.Add(carrera);
            await _context.SaveChangesAsync();
        }
    
        public async Task Delete(string Id)
        {
            var itemToRemove = await _context.CARRERA.FindAsync(Id);
            if (itemToRemove == null)
                throw new NullReferenceException();
            
            // Borra el objeto
            _context.CARRERA.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }
    
        public async Task<Carrera> Get(string Id)
        {
            return await _context.CARRERA.FindAsync(Id);
        }
    
        public async Task<IEnumerable<Carrera>> GetAll()
        {
            return await _context.CARRERA.ToListAsync();
        }
    
        public async Task Update(Carrera carrera, string id)
        {
            var itemToUpdate = await _context.CARRERA.FindAsync(id);
            if (itemToUpdate == null)
                throw new NullReferenceException();
            itemToUpdate.Nombre = carrera.Nombre;
            itemToUpdate.Nombre_pista = carrera.Nombre_pista;
            itemToUpdate.Fecha_inicio = carrera.Fecha_inicio;
            itemToUpdate.Fecha_fin = carrera.Fecha_fin;
            itemToUpdate.Estado = carrera.Estado;

            await _context.SaveChangesAsync();
    
        }

    }
}