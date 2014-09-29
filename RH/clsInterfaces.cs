using RH.Domain;
using System;
using System.Collections.Generic;
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

}
