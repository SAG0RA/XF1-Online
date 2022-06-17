using System.Collections.Generic;
using System.Threading.Tasks;
using XF1Api.Models;
using Microsoft.Extensions.Configuration;

namespace XF1Api
{
    public interface IEquipoRepository
    {
        Task<Equipo> Get(int Id);
        Task<IEnumerable<Equipo>> GetAll();
        Task Add(Equipo equipo);
        Task Delete(int Id);
        Task Update(Equipo equipo, int id);           
    }
}