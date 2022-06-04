using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace XF1Api.Models
{
    public class Escuderia
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public int? Precio { get; set; }
    }
}
