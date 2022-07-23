using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class TipoCliente
    {
        public TipoCliente()
        {
            Cliente = new HashSet<Cliente>();
        }

        public string IdTipoCliente { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
