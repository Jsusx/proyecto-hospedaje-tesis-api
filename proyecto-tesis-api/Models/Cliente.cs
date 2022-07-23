using System;
using System.Collections.Generic;

namespace proyecto_tesis_api.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string TipoDocumento { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Telefono { get; set; }
        public string Nacionalidad { get; set; }
        public bool Estado { get; set; }
        public string IdTipoCliente { get; set; }

        public virtual TipoCliente IdTipoClienteNavigation { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
