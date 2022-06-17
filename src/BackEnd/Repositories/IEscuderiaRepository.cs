using System.Collections.Generic;
using System.Threading.Tasks;
using XF1Api.Models;
using Microsoft.Extensions.Configuration;

namespace XF1Api
{
    public interface IEscuderiaRepository
    {
        Task<Escuderia> Get(int Id);
        Task<IEnumerable<Escuderia>> GetAll();
        Task Add(Escuderia escuderia);
        Task Delete(int Id);
        Task Update(Escuderia escuderia, int id);           
    }
}