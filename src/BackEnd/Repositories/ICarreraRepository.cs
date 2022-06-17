using System.Collections.Generic;
using System.Threading.Tasks;
using XF1Api.Models;
using Microsoft.Extensions.Configuration;

namespace XF1Api
{
    public interface ICarreraRepository
    {
        Task<Carrera> Get(string Id);
        Task<IEnumerable<Carrera>> GetAll();
        Task Add(Carrera carrera);
        Task Delete(string Id);
        Task Update(Carrera carrera, string id);           
    }
}