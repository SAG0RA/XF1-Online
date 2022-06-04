using System;
using System.Collections.Generic;

namespace XF1Api.Models
{
    public class Piloto
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } = null!;
        public int? Precio { get; set; }
    }
}
