using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_tesis_api.Models
{
    public partial class ReservaChatText
    {
        public string IdReservaChatText { get; set; }
        public string Tipo { get; set; }
        public string Texto { get; set; }
        [JsonIgnore]
        [NotMapped]
        public IFormFile Imagen { get; set; }
        public string Formato { get; set; }
        public string IdReservaChat { get; set; }

        public virtual ReservaChat IdReservaChatNavigation { get; set; }
    }
}
