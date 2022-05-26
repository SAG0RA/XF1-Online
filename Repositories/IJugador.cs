using XFIA_API.Models;

namespace XFIA_API.Repositories
{
    public interface IJugador
    {
        Task<IEnumerable<Jugador>> GetInfoJugador(char nombre_usuario);
        Task<bool> InsertJugador(Jugador jugador);
        Task<bool> UpdateInfoJugador(Jugador jugador);
        Task<bool> DeleteJugador(Jugador jugador);


    }
}
