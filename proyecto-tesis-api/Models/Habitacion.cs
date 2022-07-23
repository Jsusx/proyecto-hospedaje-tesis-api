using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class Habitacion
    {
        public Habitacion()
        {
            DetalleReserva = new HashSet<DetalleReserva>();
        }

        public string IdHabitacion { get; set; }
        public int NroHabitacion { get; set; }
        public string IdTipoHabitacion { get; set; }
        public int Piso { get; set; }
        public bool Estado { get; set; }

        public virtual TipoHabitacion IdTipoHabitacionNavigation { get; set; }
        public virtual ICollection<DetalleReserva> DetalleReserva { get; set; }
    }
}
