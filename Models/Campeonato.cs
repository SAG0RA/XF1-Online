namespace XFIA_API.Models
{
    public class Campeonato
    {
        public long id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_inicio { get; set; } 
        public DateTime Fecha_fin { get; set; }
        public string Descripcion_reglas { get; set; }
    }
}
