using System;
using System.Text;
using System.Collections.Generic;


namespace RH.Domain {
    
    public class Vacacion {
        public virtual int Vacacionval { get; set; }
        public virtual int? Empleado { get; set; }
        public virtual string Motivo { get; set; }
        public virtual DateTime? Fecha { get; set; }
        public virtual int? DiaCompleto { get; set; }
        public virtual string Horas { get; set; }
    }
}
