using System.Collections.Generic;
using System.Threading.Tasks;
using XF1Api.Models;
using Microsoft.Extensions.Configuration;

namespace XF1Api
{
    public interface IJugadorRepository
    {
        Task<Jugador> Get(int Id);
        Task<IEnumerable<Jugador>> GetAll();
        Task Add(Jugador jugador);
        Task Delete(int Id);
        Task Update(Jugador jugador, int id);           
    }
}