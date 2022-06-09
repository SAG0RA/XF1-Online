using System;
using System.Collections.Generic;

namespace XF1Api.Models
{
    public class Carrera
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Nombre_pista { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Estado { get; set; } = null!;
        public string Id_Campeonato { get; set; } = null!;
    }
}
