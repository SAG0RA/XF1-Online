using System;

namespace XF1Api.Dtos
{
    public class CreateEscuderiaDto
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public int? Precio { get; set; }
        public int? Puntaje { get; set; }

    }
}