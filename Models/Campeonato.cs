using System;
using System.Collections.Generic;

namespace XF1Api.Models
{
    public class Campeonato
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? DescripcionReglas { get; set; }
    }
}
