using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2.Entity
{
    public class Viajes
    {
        public string NumeroViaje { get; set; }
        public string nro_pla { get; set; }
        public string DescripcionRuta { get; set; }  
        public string HoraSalida { get; set; }
        public DateTime? FechaViaje { get; set; }
        public decimal? CostoViaje { get; set; }
        public string NombreChofer { get; set; }
    }
}
