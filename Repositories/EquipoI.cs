using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface EquipoI
    {
        Task<IEnumerable<Equipo>> GetInfoEquipo(long id);
        Task<bool> InsertEquipo(Equipo equipo);
        Task<bool> UpdateInfoEquipo(Equipo equipo);
        Task<bool> DeleteEquipo(Equipo equipo);

    }
}
