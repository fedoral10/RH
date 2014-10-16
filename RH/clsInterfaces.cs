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
        PropiedadNumerica omg_cEmpleado;
        PropiedadCadenaTexto omg_cPNombre;
        PropiedadCadenaTexto omg_cSNombre;
        PropiedadCadenaTexto omg_cPApellido;
        PropiedadCadenaTexto omg_cSApellido;
        PropiedadCadenaTexto omg_cCedula;
        PropiedadFecha omg_cFechaNacimiento;
        PropiedadNumerica omg_cNumeroInss;
        PropiedadNumerica omg_cSalario;
        public CrearEmpleado()
        {
            this.Text = "Nuevo Empleado";
            componentes();
            this.Alinear();
        }
        private void componentes()
        { 
            //Empleado 

            omg_cEmpleado = new PropiedadNumerica("No Empleado: ", PropiedadNumerica.TIPO.ENTERA);
            omg_cEmpleado.omgEtiqueta.Text = "ID";
            omg_cPNombre = new PropiedadCadenaTexto();
            
            omg_cSNombre = new PropiedadCadenaTexto();
            omg_cPApellido = new PropiedadCadenaTexto();
            omg_cSApellido = new PropiedadCadenaTexto();
            omg_cCedula = new PropiedadCadenaTexto();
            omg_cFechaNacimiento = new PropiedadFecha();
            omg_cNumeroInss = new PropiedadNumerica("Inss: ", PropiedadNumerica.TIPO.ENTERA);
            omg_cSalario = new PropiedadNumerica("Salario: ", PropiedadNumerica.TIPO.FLOTANTE);
            omg_cPNombre.omgEtiqueta.Text = "Primer Nombre: ";
            omg_cSNombre.omgEtiqueta.Text = "Segundo Nombre: ";
            omg_cPApellido.omgEtiqueta.Text = "Primer Apellido: ";
            omg_cSApellido.omgEtiqueta.Text = "Segundo Apellido: ";
            omg_cNumeroInss.omgEtiqueta.Text = "No INSS: ";
            omg_cSalario.omgEtiqueta.Text = "Salario Base: ";
            omg_cCedula.omgEtiqueta.Text = "Cédula: ";
            omg_cFechaNacimiento.omgEtiqueta.Text = "Fecha de Nacimiento: ";
            this.AgregarControl(omg_cEmpleado);
            this.AgregarControl(omg_cPNombre);
            this.AgregarControl(omg_cSNombre);
            this.AgregarControl(omg_cPApellido);
            this.AgregarControl(omg_cSApellido);
            this.AgregarControl(omg_cCedula);
            this.AgregarControl(omg_cFechaNacimiento);
            this.AgregarControl(omg_cNumeroInss);
            this.AgregarControl(omg_cSalario);
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void guardar()
        {
            Empleado emp = new Empleado();
            emp.EmpleadoID = decimal.ToInt32(this.omg_cEmpleado.omgCuadro.Value);
            emp.PrimerNombre = this.omg_cPNombre.omgCuadro.Text;
            emp.SegundoNombre = this.omg_cSNombre.omgCuadro.Text;
            emp.PrimerApellido = this.omg_cPNombre.omgCuadro.Text;
            emp.SegundoApellido = this.omg_cSApellido.omgCuadro.Text;
            emp.Cedula = this.omg_cCedula.omgCuadro.Text;
            emp.NumeroInss = this.omg_cNumeroInss.omgCuadro.Value.ToString();
            emp.SalarioBase = this.omg_cSalario.omgCuadro.Value;
            emp.FechaNacimiento = this.omg_cFechaNacimiento.omgCuadro.Value;

            clsRepo repo = new clsRepo();
            repo.Insertar<Empleado>(emp);

        }
    }
    public class CatalogoEmpleado : frmCatalogoGenerico
    {
        DevExpress.XtraGrid.Columns.GridColumn omgCol_ID;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_Nombre1;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_Nombre2;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_Apellido1;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_Apellido2;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_Cedula;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_FechaNacimiento;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_Inss;
        DevExpress.XtraGrid.Columns.GridColumn omgCol_SalarioBase;

        public CatalogoEmpleado(string spNombre)
        {
            this.Text = spNombre;
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
            omgCol_ID = this.Agregar_Columna("ID", "EmpleadoID", "colID");
            omgCol_Nombre1 = this.Agregar_Columna("Primer Nombre", "PrimerNombre", "colNombre1");
            omgCol_Nombre2 = this.Agregar_Columna("Segundo Nombre", "SegundoNombre", "colNombre2");
            omgCol_Apellido1 = this.Agregar_Columna("Primer Apellido", "PrimerApellido", "colApellido1");
            omgCol_Apellido2 = this.Agregar_Columna("Segundo Apellido", "SegundoApellido", "colApellido2");
            omgCol_Cedula = this.Agregar_Columna("Cédula", "Cedula", "colCedula");
            omgCol_FechaNacimiento = this.Agregar_Columna("Fecha Nacimiento",  "FechaNacimiento", "colFechaNacimiento");
            omgCol_Inss = this.Agregar_Columna("No Inss", "NumeroInss", "colInss");
            omgCol_SalarioBase = this.Agregar_Columna("Salario Base", "SalarioBase", "colSalario");
            

            DataTable dt = new DataTable();
            dt = clsRepoConvertidor.Seleccionar_Datatable<Empleado>();
            this.Establece_Datasource(dt);
        }
    }
}
