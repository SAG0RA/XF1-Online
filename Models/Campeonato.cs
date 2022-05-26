namespace XFIA_API.Models
{
    public class Campeonato
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public DateTime fecha_inicio { get; set; } 
        public DateTime fecha_fin { get; set; }
        public string descripcion_reglas { get; set; }
    }
}
