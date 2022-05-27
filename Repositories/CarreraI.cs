using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface CarreraI
    {
        Task<IEnumerable<Carrera>> GetInfoCarrera(long id);
        Task<bool> InsertCarrera(Carrera carrera);
        Task<bool> UpdateInfoCarrera(Carrera carrera);
        Task<bool> DeleteCarrera(Carrera carrera);
    }
}
