using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;
using T2.SQLServer;

namespace T2.MainModel
{
    public class ChoferManager
    {

        private Chofer_DL choferDL = new Chofer_DL();
        public List<Chofer> Mostrar_Chofer() { return choferDL.MostrarChofer(); }


    }
}
