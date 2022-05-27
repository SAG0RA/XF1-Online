using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface JugadorI
    {
        Task<IEnumerable<Equipo>> GetInfoJugador(char Nombre_usuario);
        Task<bool> InsertJugador(Jugador jugador);
        Task<bool> UpdateInfoJugador(Jugador jugador);
        Task<bool> DeleteJugador(Jugador jugador);
    }
}
