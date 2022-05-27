using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface CampeonatoI
    {
        Task<IEnumerable<Campeonato>> GetInfoCampeonato(long id);
        Task<bool> InsertCampeonato(Campeonato campeonato);
        Task<bool> UpdateInfoCampeonato(Campeonato campeonato);
        Task<bool> DeleteCampeonato(Campeonato campeonato);
    }
}
