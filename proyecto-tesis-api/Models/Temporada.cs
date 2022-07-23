using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class Temporada
    {
        public string IdTemporada { get; set; }
        public int Descuento { get; set; }
        public int Inicio { get; set; }
        public int Fin { get; set; }
    }
}
