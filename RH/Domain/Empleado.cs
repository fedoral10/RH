using System;
using System.Text;
using System.Collections.Generic;


namespace RH.Domain {
    
    public class Empleado {
        public virtual int EmpleadoID { get; set; }
        public virtual string PrimerNombre { get; set; }
        public virtual string SegundoNombre { get; set; }
        public virtual string PrimerApellido { get; set; }
        public virtual string SegundoApellido { get; set; }
        public virtual string Cedula { get; set; }
        public virtual DateTime? FechaNacimiento { get; set; }
        public virtual string NumeroInss { get; set; }
        public virtual decimal? SalarioBase { get; set; }
        public virtual Iesi.Collections.Generic.ISet<PagoHist> PagoHistID { get; set; }
        public virtual Iesi.Collections.Generic.ISet<Vacacion> VacacionID { get; set; }
        public virtual Iesi.Collections.Generic.ISet<SalarioBaseHist> SalarioBaseHistID { get; set; }
    }
}
