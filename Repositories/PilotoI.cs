using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface PilotoI
    {
        Task<IEnumerable<Piloto>> GetInfoPiloto(long id);
        Task<bool> InsertPiloto(Piloto piloto);
        Task<bool> UpdateInfoPiloto(Piloto piloto);
        Task<bool> DeletePiloto(Piloto piloto);
    }
}
