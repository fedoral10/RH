using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RH
{
    public partial class frmCatalogoGenerico : Form
    {
        public frmCatalogoGenerico()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
        }
        public frmCatalogoGenerico(string Nombre)
        {
            InitializeComponent();
            this.Text = Nombre;
            gridView1.OptionsBehavior.ReadOnly = true;
            gridView1.OptionsBehavior.Editable = false;
        }
        public DevExpress.XtraGrid.Columns.GridColumn Agregar_Columna(string Texto, string Nombre_Columna_db,string Nombre_Columna_Control)
        { 
            DevExpress.XtraGrid.Columns.GridColumn col = new DevExpress.XtraGrid.Columns.GridColumn();
            col.Name = Nombre_Columna_Control;
            col.FieldName=Nombre_Columna_db;
            col.Caption=Texto;
            col.Visible = true;
            
            gridView1.Columns.Add(col);
            gridView1.BestFitColumns();
            return col;
        }
        public void Eliminar_Columna(DevExpress.XtraGrid.Columns.GridColumn Columna)
        {
            gridView1.Columns.Remove(Columna);
        }

        public void Establece_Datasource(Object ds)
        {
            this.gridControl1.DataSource = ds;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
