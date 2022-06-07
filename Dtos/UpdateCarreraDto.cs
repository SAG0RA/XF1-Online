using System;

namespace XF1Api.Dtos
{
    public class UpdateCarreraDto
    {
        public string Nombre { get; set; }
        public string Nombre_pista { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Estado { get; set; }

    }
}