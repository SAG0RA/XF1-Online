using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XF1Api.Models;

// Represents a session with the database and can be used to query and save instances of your entities.

namespace XF1Api.Data
{
    public interface IXFIAOnlinedatabaseContext
    {
        DbSet<Campeonato> CAMPEONATO { get; init; }
        DbSet<Carrera> CARRERA { get; init; }
        DbSet<Equipo> EQUIPO { get; init; }

        DbSet<Escuderia> ESCUDERIA { get; init; }
        DbSet<Jugador> JUGADOR { get; init; }
        DbSet<Piloto> PILOTO { get; init; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}