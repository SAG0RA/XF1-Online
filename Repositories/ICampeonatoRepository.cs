using System.Collections.Generic;
using System.Threading.Tasks;
using XF1Api.Models;
using Microsoft.Extensions.Configuration;

namespace XF1Api
{
    public interface ICampeonatoRepository
    {
        Task<Campeonato> Get(string Id);
        Task<IEnumerable<Campeonato>> GetAll();
        Task Add(Campeonato campeonato);
        Task Delete(string Id);
        Task Update(Campeonato campeonato);           
    }
}