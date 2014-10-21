using System;
using System.Text;
using System.Collections.Generic;


namespace RH.Domain {
    
    public class SalarioBaseHist {
        public virtual int SalarioBaseHistID { get; set; }
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
