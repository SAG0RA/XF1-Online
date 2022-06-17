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

        public DbSet<Campeonato> CAMPEONATO { get; init; }
        public DbSet<Carrera> CARRERA { get; init; }
        public DbSet<Equipo> EQUIPO { get; init; } 
        public DbSet<Escuderia> ESCUDERIA { get; init; } 
        public DbSet<Jugador> JUGADOR { get; init; }
        public DbSet<Piloto> PILOTO { get; init; }

    }
}

        
