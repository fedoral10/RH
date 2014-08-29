using System;
using System.Text;
using System.Collections.Generic;


namespace RH.Domain {
    
    public class PagoHist {
        public virtual int PagoHistID { get; set; }
        public virtual int? Empleado { get; set; }
        public virtual string Monto { get; set; }
    }
}
