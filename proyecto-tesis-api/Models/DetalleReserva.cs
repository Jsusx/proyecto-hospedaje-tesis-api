using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class DetalleReserva
    {
        public string IdDetalleReserva { get; set; }
        public string IdReserva { get; set; }
        public string IdHabitacion { get; set; }

        public virtual Habitacion IdHabitacionNavigation { get; set; }
        public virtual Reserva IdReservaNavigation { get; set; }
    }
}
