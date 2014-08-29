using System;
using System.Text;
using System.Collections.Generic;


namespace RH.Domain {
    
    public class SalarioBaseHist {
        public virtual int SalarioBaseHistval { get; set; }
        public virtual int? Empleado { get; set; }
        public virtual string Monto { get; set; }
    }
}
