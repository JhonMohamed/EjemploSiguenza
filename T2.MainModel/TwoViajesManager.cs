using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;
using T2.SQLServer;

namespace T2.MainModel
{
    public class TwoViajesManager
    {
        private SP_VIAJES viajesSP = new SP_VIAJES();
        public List<Viajes> Listar_Viajes() { return viajesSP.ListarViajes(); }

    }
}
