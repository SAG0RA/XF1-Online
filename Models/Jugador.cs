using System;
using System.Collections.Generic;

namespace XF1Api.Models
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombre_usuario { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Rango_edad { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string? Contrasenia { get; set; }
    }
}
