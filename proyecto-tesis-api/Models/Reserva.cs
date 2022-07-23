using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class Reserva
    {
        public Reserva()
        {
            DetalleReserva = new HashSet<DetalleReserva>();
            ReservaChat = new HashSet<ReservaChat>();
        }

        public string IdReserva { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public decimal Costo { get; set; }
        public string Codigo { get; set; }
        public int Huespedes { get; set; }
        public string Comprobante { get; set; }
        public string Descripcion { get; set; }
        public string IdCliente { get; set; }
        public string IdEmpleado { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empleado IdEmpleadoNavigation { get; set; }
        public virtual ICollection<DetalleReserva> DetalleReserva { get; set; }
        public virtual ICollection<ReservaChat> ReservaChat { get; set; }
    }
}
