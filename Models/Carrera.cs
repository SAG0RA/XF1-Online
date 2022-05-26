namespace XFIA_API.Models
{
    public class Carrera
    {
        public long id { get; set; }
        public string nombre { get; set; }
        public string nombre_pista { get; set; }
        public string pais { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string estado { get; set; }
        public long id_campeonato { get; set; }
    }
}
