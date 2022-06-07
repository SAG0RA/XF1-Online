using System;

namespace XF1Api.Dtos
{
    public class UpdateCampeonatoDto
    {   
        public string Nombre { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string? Descripcion_reglas { get; set; }

    }
}