using System;
using System.Text;
using System.Collections.Generic;


namespace RH.Domain {
    
    public class Empleado {
        public virtual int Empleadoval { get; set; }
        public virtual string PrimerNombre { get; set; }
        public virtual string SegundoNombre { get; set; }
        public virtual string PrimerApellido { get; set; }
        public virtual string SegundoApellido { get; set; }
        public virtual string Cedula { get; set; }
        public virtual DateTime? FechaNacimiento { get; set; }
        public virtual string NumeroInss { get; set; }
        public virtual decimal? SalarioBase { get; set; }
    }
}
