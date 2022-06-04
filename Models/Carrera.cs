using System;
using System.Collections.Generic;

namespace XF1Api.Models
{
    public class Carrera
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string NombrePista { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = null!;
        public string IdCampeonato { get; set; } = null!;
    }
}
