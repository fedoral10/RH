using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
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
    public partial class frmEdicionGenerico : Form
    {
        //Panel 
        LayoutControl ogpPanelPrincipal;
        public frmEdicionGenerico()
        {
            InitializeComponent();
            ogpPanelPrincipal = new LayoutControl();
            ogpPanelPrincipal.Location = new Point(0, 0);
            this.Controls.Add(ogpPanelPrincipal);
            
        }

        private void cambiar_tamanio_panel()
        {
            ogpPanelPrincipal.Size = this.Size;

            ogpPanelPrincipal.ResumeLayout(false);
            ogpPanelPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        public void AgregarControl(Control control)
        {
            this.ogpPanelPrincipal.Controls.Add(control);
        }
        public void EliminaControl(Control control)
        { 
            //Pendiente
        }

        private void frmEdicionGenerico_Load(object sender, EventArgs e)
        {
            cambiar_tamanio_panel();

        }
    }

    public class PropiedadNumerica : NumericUpDown
    {
        public enum TIPO {FLOTANTE,ENTERA}
        string ogsNombre;
        public PropiedadNumerica(TIPO tipo,string nombre)
        {
            if (tipo == TIPO.FLOTANTE)
            {
                this.DecimalPlaces = 2;
            }
            else 
            {
                this.DecimalPlaces = 0;
            }
            this.Maximum = 99999999999999999;
            this.Minimum = -99999999999999999;
            this.Value = 0;
            this.Size = new Size(100, 20);
        }
        public PropiedadNumerica(TIPO tipo,decimal valor_inicial)
        {
            if (tipo == TIPO.FLOTANTE)
            {
                this.DecimalPlaces = 2;
            }
            else
            {
                this.DecimalPlaces = 0;
            }
            this.Maximum = 99999999999999999;
            this.Minimum = -99999999999999999;
            this.Value = valor_inicial;
            this.Size = new Size(100, 20);
        }
        public PropiedadNumerica(decimal valor_inicial,int cantidad_decimales )
        {

            this.DecimalPlaces = cantidad_decimales;

            this.Maximum = 99999999999999999;
            this.Minimum = -99999999999999999;
            this.Value = valor_inicial;
            this.Size = new Size(100, 20);
            this.Location = new Point(0, 0);
        }
        public PropiedadNumerica(TIPO tipo,decimal minimo,decimal maximo)
        {
            if (tipo == TIPO.FLOTANTE)
            {
                this.DecimalPlaces = 2;
            }
            else
            {
                this.DecimalPlaces = 0;
            }
            this.Maximum = maximo;
            this.Minimum = -minimo;
            this.Value = 0;
            this.Size = new Size(100, 20);
        }
        public PropiedadNumerica(TIPO tipo, decimal minimo, decimal maximo,decimal valor_inicial)
        {
            if (tipo == TIPO.FLOTANTE)
            {
                this.DecimalPlaces = 2;
            }
            else
            {
                this.DecimalPlaces = 0;
            }
            this.Maximum = maximo;
            this.Minimum = -minimo;
            this.Value = valor_inicial;
            this.Size = new Size(100, 20);
        }
        public string Nombre
        {
            get { return ogsNombre; }
            set { ogsNombre = value; }
        }



        public Control ObtenerControl()
        {
            Label etiqueta = new Label();
            Control control = new Control();
            
            if (string.IsNullOrEmpty(this.Nombre))
            {
                etiqueta.Text = "Numerico: ";
            }
            else
            {
                etiqueta.Text = this.Nombre + ": ";
            }
            Size textSize = TextRenderer.MeasureText(etiqueta.Text, etiqueta.Font);
            etiqueta.Location = new Point(0, 0);
            control.Controls.Add(etiqueta);
            control.Controls.Add(this);
            control.Size = new Size(this.Width, this.Height + etiqueta.Height + 5);
            control.Location = new Point(0, 0);
            control.ResumeLayout(false);
            control.PerformLayout();
            return control;
        }
    }

    public class PropiedadCadenaTexto : TextBox
    {
        public enum TIPO {MULTILINEA,LINEA_UNICA}
        public PropiedadCadenaTexto()
        {
            this.Size = new Size(100, 20);
        }
        public PropiedadCadenaTexto(int ancho, int alto)
        {
            this.Size = new Size(ancho, alto);
        }

    }

    public class PropiedadFecha : DateTimePicker
    {
        public enum TIPO {FECHA_CORTA,FECHA_LARGA,FECHA_CORTA_HORA,FECHA_LARGA_HORA}

        Size ogsFormato_Largo = new Size(200, 20);//long
        Size ogsFormato_Corto = new Size(80, 20);//short
        Size ogsFormato_Largo_Hora = new Size(270, 20);//long time
        Size ogsFormato_Corto_Hora = new Size(150, 20);//short time

        public PropiedadFecha()
        {
            this.Format = DateTimePickerFormat.Short;
            this.Size = ogsFormato_Corto;
        }
        public PropiedadFecha(TIPO tipo)
        {
            cambia_formato(this,tipo);
        }
        private void cambia_formato(DateTimePicker dtp, TIPO tipo)
        { 
            
            switch(tipo)
            {
                case TIPO.FECHA_CORTA:
                    dtp.Format = DateTimePickerFormat.Short;
                    dtp.Size = ogsFormato_Corto;
                break;
                case TIPO.FECHA_LARGA:
                    dtp.Format = DateTimePickerFormat.Long;
                    dtp.Size = ogsFormato_Largo;
                break;
                case TIPO.FECHA_CORTA_HORA:
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
                    dtp.Size = ogsFormato_Corto_Hora;
                break;
                case TIPO.FECHA_LARGA_HORA:
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dddd, dd de MMMM de yyyy hh:mm:ss tt";
                    dtp.Size = ogsFormato_Largo_Hora;
                break;
            }
        }
    }
}
