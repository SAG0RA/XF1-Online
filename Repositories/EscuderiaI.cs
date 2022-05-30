using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface EscuderiaI
    {
        Task<IEnumerable<Escuderia>> GetInfoEscuderia(String nombre);
        Task<bool> InsertEscuderia(Escuderia jugador);
        Task<bool> UpdateInfoEscuderia(Escuderia jugador);
        Task<bool> DeleteEscuderia(Escuderia jugador);
    }
}
