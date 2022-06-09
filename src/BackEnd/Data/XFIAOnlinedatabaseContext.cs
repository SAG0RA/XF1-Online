using Microsoft.EntityFrameworkCore;
using XF1Api.Models;
using System.Threading.Tasks;


namespace XF1Api.Data
{
    public class XFIAOnlinedatabaseContext : DbContext, IXFIAOnlinedatabaseContext
    {

        public XFIAOnlinedatabaseContext(DbContextOptions<XFIAOnlinedatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campeonato> CAMPEONATO { get; init; } = null!;
        public virtual DbSet<Carrera> CARRERA { get; init; } = null!;
        public virtual DbSet<Equipo> EQUIPO { get; init; } = null!;

        public virtual DbSet<Escuderia> ESCUDERIA { get; init; } = null!;
        public virtual DbSet<Jugador> JUGADOR { get; init; } = null!;
        public virtual DbSet<Piloto> PILOTO { get; init; } = null!;

    }
}

        
