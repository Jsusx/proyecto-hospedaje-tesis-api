using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class ReservaChat
    {
        public ReservaChat()
        {
            ReservaChatText = new HashSet<ReservaChatText>();
        }

        public string IdReservaChat { get; set; }
        public string Titulo { get; set; }
        public string IdReserva { get; set; }

        public virtual Reserva IdReservaNavigation { get; set; }
        public virtual ICollection<ReservaChatText> ReservaChatText { get; set; }
    }
}
