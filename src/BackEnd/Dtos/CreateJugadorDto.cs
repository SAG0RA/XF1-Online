using System;

namespace XF1Api.Dtos
{
    public class CreateJugadorDto
    {
        public int Id { get; set; }
        public string Nombre_usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Rango_edad { get; set; }
        public string Pais { get; set; }
        public string Contrasenia { get; set; }

    }
}