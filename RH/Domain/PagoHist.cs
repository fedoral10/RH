using System;
using System.Text;
using System.Collections.Generic;
using RH.Domain;

namespace RH.Domain {
    
    public class PagoHist {
        public virtual int PagoHistID { get; set; }
        //public virtual int? Empleado { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual string Monto { get; set; }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {

            return base.GetHashCode();
        }
    }
}
