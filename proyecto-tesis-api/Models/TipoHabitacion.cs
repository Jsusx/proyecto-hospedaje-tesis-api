using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class TipoHabitacion
    {
        public TipoHabitacion()
        {
            Habitacion = new HashSet<Habitacion>();
        }

        public string IdTipoHabitacion { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public int? Limite { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Habitacion> Habitacion { get; set; }
    }
}
