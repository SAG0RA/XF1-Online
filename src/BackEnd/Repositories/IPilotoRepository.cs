using System.Collections.Generic;
using System.Threading.Tasks;
using XF1Api.Models;
using Microsoft.Extensions.Configuration;

namespace XF1Api
{
    public interface IPilotoRepository
    {
        Task<Piloto> Get(int Id);
        Task<IEnumerable<Piloto>> GetAll();
        Task Add(Piloto piloto);
        Task Delete(int Id);
        Task Update(Piloto piloto, int id);           
    }
}