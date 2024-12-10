using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;
using T2.SQLServer;

namespace T2.MainModel
{
    public class BusManager
    {
        private Bus_LP busLp = new Bus_LP();
        public List<Bus> Listar_Buses() { return busLp.ListarBuses(); }
    }
}
