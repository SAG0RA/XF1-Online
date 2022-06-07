using System;

namespace XF1Api.Dtos
{
    public class CreateCarreraDto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Nombre_pista { get; set; }
        public string Pais { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Estado { get; set; }
        public string Id_Campeonato { get; set; }

    }
}