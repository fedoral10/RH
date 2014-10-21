using System;
using System.Text;
using System.Collections.Generic;


namespace RH.Domain {
    
    public class Vacacion {
        public virtual int VacacionID { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual string Motivo { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual int? DiaCompleto { get; set; }
        public virtual string Horas { get; set; }
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
