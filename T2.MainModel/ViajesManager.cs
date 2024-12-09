using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;

namespace T2.MainModel
{
    public class ViajesManager
    {
        private SP_Viaje_DL viajeSP = new SP_Viaje_DL();
        public List<Viaje> Lista_Viaje(string chofer = null, int? anio = null) { return viajeSP.ListaViaje(chofer, anio); }
        //public List<Viaje> Filtrar_Viaje(string chofer = null, int? anio = null) { return viajeSP.FiltrarViaje(chofer, anio); }

    }
}
