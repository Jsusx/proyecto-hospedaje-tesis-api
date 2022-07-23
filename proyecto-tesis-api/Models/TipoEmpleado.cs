using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class TipoEmpleado
    {
        public TipoEmpleado()
        {
            Empleado = new HashSet<Empleado>();
        }

        public string IdTipoEmpleado { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Empleado> Empleado { get; set; }
    }
}
