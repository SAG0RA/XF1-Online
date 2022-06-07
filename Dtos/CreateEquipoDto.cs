using System;

namespace XF1Api.Dtos
{
    public class CreateEquipoDto
    {
        public int Id { get; set; } 
        public int Jugador_id { get; set; } 
        public int Escuderia_id { get; set; }

    }
}