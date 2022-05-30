using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface EquipoPilotoI
    {
        Task<IEnumerable<Equipo_Piloto>> GetInfoEquipo_Piloto(long equipo_id);
        Task<bool> InsertEquipo_Piloto(Equipo_Piloto equipo_Piloto);
        Task<bool> UpdateInfoEquipo_Piloto(Equipo_Piloto equipo_Piloto);
        Task<bool> DeleteEquipo_Piloto(Equipo_Piloto equipo_Piloto);
    }
}
