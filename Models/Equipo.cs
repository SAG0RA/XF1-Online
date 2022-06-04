using System;
using System.Collections.Generic;

namespace XF1Api.Models
{
    public class Equipo
    {
        public string Id { get; set; } = null!;
        public string JugadorNombreUsuario { get; set; } = null!;
        public string? EscuderiaNombre { get; set; }
    }
}
