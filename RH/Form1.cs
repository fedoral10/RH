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
            clsRepo repo = new clsRepo();
            Empleado ex = new Empleado();
            ex.PrimerApellido ="asdf";
            ex.SalarioBase = 98;
            ex.EmpleadoID = 12;

            repo.Insertar<Empleado>(ex);
        }
    }
}
