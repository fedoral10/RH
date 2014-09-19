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

        private void button1_Click(object sender, EventArgs e)
        {
            /*clsRepo repo = new clsRepo();
            Empleado ex = new Empleado();
            ex.PrimerApellido ="asdf";
            ex.SalarioBase = 98;
            ex.EmpleadoID = 12;

            repo.Insertar<Empleado>(ex);*/

            frmEdicionGenerico frm = new frmEdicionGenerico();
            PropiedadNumerica num1 = new PropiedadNumerica(0,0);
            PropiedadNumerica num2 = new PropiedadNumerica(0, 2);
            PropiedadNumerica num3 = new PropiedadNumerica(2,1);
            frm.AgregarControl(num1.ObtenerControl());
            frm.AgregarControl(num2.ObtenerControl());
            frm.AgregarControl(num3.ObtenerControl());
            frm.ShowDialog();

        }
    }
}
