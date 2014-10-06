using RH.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RH
{

    public class CrearEmpleado : frmEdicionGenerico
    {
        /**/
        PropiedadNumerica cEmpleado;
        PropiedadCadenaTexto cPNombre;
        PropiedadCadenaTexto cSNombre;
        PropiedadCadenaTexto cPApellido;
        PropiedadCadenaTexto cSApellido;
        PropiedadCadenaTexto cCedula;
        PropiedadFecha cFechaNacimiento;
        PropiedadNumerica cNumeroInss;
        PropiedadNumerica cSalario;
        public CrearEmpleado()
        {
            this.Text = "Nuevo Empleado";
            componentes();
            this.Alinear();
        }
        private void componentes()
        { 
            //Empleado 

            cEmpleado = new PropiedadNumerica("No Empleado: ", PropiedadNumerica.TIPO.ENTERA);
            cEmpleado.etiqueta.Text = "ID";
            cPNombre = new PropiedadCadenaTexto();
            
            cSNombre = new PropiedadCadenaTexto();
            cPApellido = new PropiedadCadenaTexto();
            cSApellido = new PropiedadCadenaTexto();
            cCedula = new PropiedadCadenaTexto();
            cFechaNacimiento = new PropiedadFecha();
            cNumeroInss = new PropiedadNumerica("Inss: ", PropiedadNumerica.TIPO.ENTERA);
            cSalario = new PropiedadNumerica("Salario: ", PropiedadNumerica.TIPO.FLOTANTE);
            cPNombre.etiqueta.Text = "Primer Nombre: ";
            cSNombre.etiqueta.Text = "Segundo Nombre: ";
            cPApellido.etiqueta.Text = "Primer Apellido: ";
            cSApellido.etiqueta.Text = "Segundo Apellido: ";
            cNumeroInss.etiqueta.Text = "No INSS: ";
            cSalario.etiqueta.Text = "Salario Base: ";
            cCedula.etiqueta.Text = "Cédula: ";
            cFechaNacimiento.etiqueta.Text = "Fecha de Nacimiento: ";
            this.AgregarControl(cEmpleado);
            this.AgregarControl(cPNombre);
            this.AgregarControl(cSNombre);
            this.AgregarControl(cPApellido);
            this.AgregarControl(cSApellido);
            this.AgregarControl(cCedula);
            this.AgregarControl(cFechaNacimiento);
            this.AgregarControl(cNumeroInss);
            this.AgregarControl(cSalario);
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            Empleado emp = new Empleado();
            emp.EmpleadoID = decimal.ToInt32(this.cEmpleado.cuadro.Value);
            emp.PrimerNombre = this.cPNombre.cuadro.Text;
            emp.SegundoNombre = this.cSNombre.cuadro.Text;
            emp.PrimerApellido = this.cPNombre.cuadro.Text;
            emp.SegundoApellido = this.cSApellido.cuadro.Text;
            emp.Cedula = this.cCedula.cuadro.Text;
            emp.NumeroInss = this.cNumeroInss.cuadro.Value.ToString();
            emp.SalarioBase = this.cSalario.cuadro.Value;
            emp.FechaNacimiento = this.cFechaNacimiento.cuadro.Value;

            clsRepo repo = new clsRepo();
            repo.Insertar<Empleado>(emp);

        }
    }
    public class CatalogoEmpleado : frmCatalogoGenerico
    {
        DevExpress.XtraGrid.Columns.GridColumn col_ID;
        DevExpress.XtraGrid.Columns.GridColumn col_Nombre1;
        DevExpress.XtraGrid.Columns.GridColumn col_Nombre2;
        DevExpress.XtraGrid.Columns.GridColumn col_Apellido1;
        DevExpress.XtraGrid.Columns.GridColumn col_Apellido2;
        DevExpress.XtraGrid.Columns.GridColumn col_Cedula;
        DevExpress.XtraGrid.Columns.GridColumn col_FechaNacimiento;
        DevExpress.XtraGrid.Columns.GridColumn col_Inss;
        DevExpress.XtraGrid.Columns.GridColumn col_SalarioBase;

        public CatalogoEmpleado(string Nombre)
        {
            this.Text = Nombre;
            this.inicializa_componentes();
        }
        private void inicializa_componentes()
        {
            clsRepo repo = new clsRepo();
            /*
            EmpleadoID
            PrimerNombre
            SegundoNombre
            PrimerApellido
            SegundoApellido
            Cedula
            FechaNacimiento
            NumeroInss
            SalarioBase
             */
            col_ID = this.agregar_columna("ID", "EmpleadoID", "colID");
            col_Nombre1 = this.agregar_columna("Primer Nombre", "PrimerNombre", "colNombre1");
            col_Nombre2 = this.agregar_columna("Segundo Nombre", "SegundoNombre", "colNombre2");
            col_Apellido1 = this.agregar_columna("Primer Apellido", "PrimerApellido", "colApellido1");
            col_Apellido2 = this.agregar_columna("Segundo Apellido", "SegundoApellido", "colApellido2");
            col_FechaNacimiento = this.agregar_columna("Fecha Nacimiento",  "FechaNacimiento", "colFechaNacimiento");
            col_Inss = this.agregar_columna("No Inss", "NumeroInss", "colInss");
            col_SalarioBase = this.agregar_columna("Salario Base", "SalarioBase", "colSalario");
            

            DataTable dt = new DataTable();
            dt = clsRepoConvertidor.Seleccionar_Datatable<Empleado>();
            this.establece_datasource(dt);
        }
    }
}
