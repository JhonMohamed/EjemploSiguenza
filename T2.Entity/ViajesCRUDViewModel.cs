using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2.Entity
{
    public class ViajesCRUDViewModel
    {
        public Viajes Viajes { get; set; }
        public List<Ruta> Rutas { get; set; }
        public List<Chofer> Chofers { get; set; }
        public List<Bus> Bus { get; set; }

    }
}
