using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RH.Domain;

namespace RH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        frmEdicionGenerico frm = new frmEdicionGenerico();
        private void button1_Click(object sender, EventArgs e)
        {
            /*clsRepo repo = new clsRepo();
            Empleado ex = new Empleado();
            ex.PrimerApellido ="asdf";
            ex.SalarioBase = 98;
            ex.EmpleadoID = 12;

            repo.Insertar<Empleado>(ex);*/

            
            /*PropiedadNumerica num1 = new PropiedadNumerica("num1",0,0);
            PropiedadNumerica num2 = new PropiedadNumerica("num2", 0, 2);
            PropiedadNumerica num3 = new PropiedadNumerica("num3",PropiedadNumerica.TIPO.FLOTANTE, 2, 1);
            PropiedadCadenaTexto cad1 = new PropiedadCadenaTexto();
            PropiedadCadenaTexto cad2 = new PropiedadCadenaTexto(PropiedadCadenaTexto.TIPO.LINEA_UNICA,200,20);
            PropiedadFecha fecha1 = new PropiedadFecha();
            PropiedadFecha fecha2 = new PropiedadFecha(PropiedadFecha.TIPO.FECHA_LARGA_HORA);
            cad1.cuadro.Name = "cade";
            frm.AgregarControl(num1);
            //this.Controls.Add(num1);
            frm.AgregarControl(num2);
            frm.AgregarControl(num3);
            frm.AgregarControl(cad1);
            frm.AgregarControl(cad2);
            frm.AgregarControl(fecha1);
            frm.AgregarControl(fecha2);
            frm.btnGuardar.Click += new EventHandler(btnGuardar_Click);
           
            frm.ShowDialog();*/
            CrearEmpleado emp = new CrearEmpleado();
            emp.ShowDialog();
            
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            Control[] x = frm.ogpPanelPrincipal.Controls.Find("cade",true);
            MessageBox.Show("Hola "+((TextBox)x[0]).Text);
        }

    }
}
