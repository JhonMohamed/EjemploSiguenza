using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2.Entity
{
    public class Viaje
    {
        public string NroVia { get; set; }    
        public int? FecVia { get; set; }  
        public string HrsSal { get; set; }    
        public string CodRut { get; set; }    
        public string DesRut { get; set; }    
        public decimal CostoVia { get; set; }
    }
}
