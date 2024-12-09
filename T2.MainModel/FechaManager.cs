using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;
using T2.SQLServer;

namespace T2.MainModel
{
    public class FechaManager
    {
        private Fecha_CL fechaCL = new Fecha_CL();
        public List<Anio> Mostrar_Fecha() { return fechaCL.MostrarFecha(); }
    }
}
