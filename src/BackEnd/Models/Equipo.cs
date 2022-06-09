using System;
using System.Collections.Generic;

namespace XF1Api.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public int Jugador_id { get; set; }
        public int Escuderia_id { get; set; }
    }
}
