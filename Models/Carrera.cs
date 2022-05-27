namespace XFIA_API.Models
{
    public class Carrera
    {
        public long id { get; set; }
        public string Nombre { get; set; }
        public string Nombre_pista { get; set; }
        public string Pais { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public string Estado { get; set; }
        public long Id_Campeonato { get; set; }
    }
}
