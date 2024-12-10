using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;
using T2.SQLServer;

namespace T2.MainModel
{
    public class RutaManager
    {
        private SP_Ruta ruta_sp = new SP_Ruta();

        public List<Ruta> Listar_Rutas() { return ruta_sp.ListarRutas(); }

    }
}
