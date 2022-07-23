using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string IdTipoEmpleado { get; set; }
        public string Correo { get; set; }

        public virtual TipoEmpleado IdTipoEmpleadoNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
