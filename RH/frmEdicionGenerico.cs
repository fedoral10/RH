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
        //LayoutControl ogpPanelPrincipal;
        public frmEdicionGenerico()
        {
            InitializeComponent();
            //ogpPanelPrincipal = new LayoutControl();
            //ogpPanelPrincipal.Location = new Point(0, 0);
            //this.cambiar_tamanio_panel();
            //this.Controls.Add(ogpPanelPrincipal);
        }
        public void AgregarControl(Control control)
        {
            this.ogpPanelPrincipal.Controls.Add(control);
            this.ogpPanelPrincipal.Refresh();
            this.ogpPanelPrincipal.Update();
            //this.Controls.Add(control);
        }
        public void EliminaControl(Control control)
        { 
            //Pendiente
        }

        private void frmEdicionGenerico_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class PropiedadNumerica : UserControl
    {
        public enum TIPO {FLOTANTE,ENTERA}
        string ogsNombre;
        public NumericUpDown cuadro;
        public Label etiqueta;
        
        private void InicializarObjetos()
        {
            //this.SuspendLayout();
            this.cuadro = new NumericUpDown();
            this.etiqueta = new Label();
            this.cuadro.Name = "cuadro";
            this.etiqueta.Name = "etiqueta";

            if (string.IsNullOrEmpty(this.Nombre))
            {
                this.etiqueta.Text = "Numerico: ";
            }
            else
            {
                this.etiqueta.Text = this.Nombre + ": ";
            }
            Size textSize = TextRenderer.MeasureText(etiqueta.Text, etiqueta.Font);
            this.etiqueta.Size = new Size(textSize.Width,cuadro.Height);
            this.etiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(etiqueta);
            this.Controls.Add(cuadro);
            this.cuadro.Location = new Point(etiqueta.Width, 1);
            
            this.Size = new Size(cuadro.Width + etiqueta.Width + 10, cuadro.Height);
            //this.BackColor = Color.Azure;
            /*this.ResumeLayout(false);
            this.PerformLayout();*/
            //this.AutoSize = true;
        }
        public string Nombre
        {
            get { return this.ogsNombre; }
            set { this.ogsNombre = value; }
        }
        private void InicializaValores(TIPO tipo, decimal valor_inicial = 0, int cantidad_decimales = 0, decimal maximo = 99999999999999999, decimal minimo = -99999999999999999)
        {
            if (tipo == TIPO.FLOTANTE &&cantidad_decimales ==0)
            {
                this.cuadro.DecimalPlaces = 2;
            }
            if(tipo == TIPO.ENTERA)
            {
                this.cuadro.DecimalPlaces = 0;
            }
            if(tipo == TIPO.FLOTANTE && cantidad_decimales != 0)
            {
                this.cuadro.DecimalPlaces = cantidad_decimales;
            }
            this.cuadro.Maximum = maximo;
            this.cuadro.Minimum = minimo;
            this.cuadro.Value = valor_inicial;
        }
        public PropiedadNumerica(string nombre,TIPO tipo)
        {
            this.Nombre = nombre;
            InicializarObjetos();
            InicializaValores(tipo);
            /*if (tipo == TIPO.FLOTANTE)
            {
                this.cuadro.DecimalPlaces = 2;
            }
            else 
            {
                this.cuadro.DecimalPlaces = 0;
            }
            this.cuadro.Maximum = 99999999999999999;
            this.cuadro.Minimum = -99999999999999999;
            this.cuadro.Value = 0;*/
            //this.cuadro.Size = new Size(100, 20);
        }
        public PropiedadNumerica(string nombre, TIPO tipo, decimal valor_inicial)
        {
            this.Nombre = nombre;
            InicializarObjetos();
            InicializaValores(tipo, valor_inicial);
            /*if (tipo == TIPO.FLOTANTE)
            {
                this.cuadro.DecimalPlaces = 2;
            }
            else
            {
                this.cuadro.DecimalPlaces = 0;
            }
            this.cuadro.Maximum = 99999999999999999;
            this.cuadro.Minimum = -99999999999999999;
            this.cuadro.Value = valor_inicial;*/
            //this.cuadro.Size = new Size(100, 20);
        }
        public PropiedadNumerica(string nombre,TIPO tipo, decimal valor_inicial, int cantidad_decimales)
        {
            this.Nombre = nombre;
            InicializarObjetos();
            InicializaValores(tipo, valor_inicial, cantidad_decimales);
            /*this.cuadro.DecimalPlaces = cantidad_decimales;

            this.cuadro.Maximum = 99999999999999999;
            this.cuadro.Minimum = -99999999999999999;
            this.cuadro.Value = valor_inicial;*/
            //this.cuadro.Size = new Size(100, 20);
        }
        public PropiedadNumerica(string nombre, TIPO tipo, decimal minimo, decimal maximo)
        {
            this.Nombre = nombre;
            InicializarObjetos();
            InicializaValores(tipo, 0,0, maximo, minimo);
            /*if (tipo == TIPO.FLOTANTE)
            {
                this.cuadro.DecimalPlaces = 2;
            }
            else
            {
                this.cuadro.DecimalPlaces = 0;
            }
            this.cuadro.Maximum = maximo;
            this.cuadro.Minimum = -minimo;
            this.cuadro.Value = 0;*/
            //this.cuadro.Size = new Size(100, 20);
        }
        public PropiedadNumerica(string nombre, TIPO tipo, decimal minimo, decimal maximo, decimal valor_inicial)
        {
            this.Nombre = nombre;
            InicializaValores(tipo, valor_inicial, 0, maximo, minimo);
            /*if (tipo == TIPO.FLOTANTE)
            {
                this.cuadro.DecimalPlaces = 2;
            }
            else
            {
                this.cuadro.DecimalPlaces = 0;
            }
            this.cuadro.Maximum = maximo;
            this.cuadro.Minimum = -minimo;
            this.cuadro.Value = valor_inicial;*/
            //this.cuadro.Size = new Size(100, 20);
        }
    }
    public class PropiedadCadenaTexto : UserControl
    {
        public enum TIPO {MULTILINEA,LINEA_UNICA}
        public TextBox cuadro;
        public Label etiqueta;
        public void InicializaValores(TIPO tipo,int ancho=100, int alto=20,string texto_inicial ="",string texto_etiqueta="")
        {
            this.cuadro = new TextBox();
            this.etiqueta = new Label();
            this.cuadro.Size = new Size(ancho, alto);
            this.cuadro.Text = texto_inicial;
            this.etiqueta.Text = texto_etiqueta;
            if (tipo == TIPO.LINEA_UNICA)
            {
                this.cuadro.Multiline = false;
            }
            else
            {
                this.cuadro.Multiline = true;
            }
            if (string.IsNullOrEmpty(texto_etiqueta))
            {
                this.etiqueta.Text = "Cadena: ";
            }
            else
            {
                this.etiqueta.Text = texto_etiqueta + ": ";
            }
            Size textSize = TextRenderer.MeasureText(etiqueta.Text, etiqueta.Font);
            this.etiqueta.Size = new Size(textSize.Width, cuadro.Height);
            this.etiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(etiqueta);
            this.Controls.Add(cuadro);
            this.cuadro.Location = new Point(etiqueta.Width, 1);

            this.Size = new Size(cuadro.Width + etiqueta.Width + 10, cuadro.Height);
        }
        public PropiedadCadenaTexto()
        {
            InicializaValores(TIPO.LINEA_UNICA);
        }
        public PropiedadCadenaTexto(TIPO tipo,int ancho, int alto)
        {
            InicializaValores(tipo,ancho, alto);
        }

    }

    public class PropiedadFecha : UserControl
    {
        public enum TIPO {FECHA_CORTA,FECHA_LARGA,FECHA_CORTA_HORA,FECHA_LARGA_HORA}

        Size ogsFormato_Largo = new Size(200, 20);//long
        Size ogsFormato_Corto = new Size(80, 20);//short
        Size ogsFormato_Largo_Hora = new Size(270, 20);//long time
        Size ogsFormato_Corto_Hora = new Size(150, 20);//short time


        public DateTimePicker cuadro;
        public Label etiqueta;

        private void InicializaValores(TIPO tipo = TIPO.FECHA_CORTA, DateTime valor_inicial=new DateTime(),string texto_etiqueta="Fecha: ")
        {
            valor_inicial = DateTime.Now;
            this.cuadro = new DateTimePicker();
            this.etiqueta = new Label();
            cambia_formato(this.cuadro, tipo);
            this.cuadro.Value = valor_inicial;
            this.etiqueta.Text = texto_etiqueta;
            Size textSize = TextRenderer.MeasureText(etiqueta.Text, etiqueta.Font);
            this.etiqueta.Size = new Size(textSize.Width, cuadro.Height);
            this.etiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(etiqueta);
            this.Controls.Add(cuadro);
            this.cuadro.Location = new Point(etiqueta.Width, 1);

            this.Size = new Size(cuadro.Width + etiqueta.Width + 10, cuadro.Height);
        }
        public PropiedadFecha()
        {
            InicializaValores();
            /*this.cuadro.Format = DateTimePickerFormat.Short;
            this.cuadro.Size = ogsFormato_Corto;*/
        }
        public PropiedadFecha(TIPO tipo)
        {
            InicializaValores(tipo);
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
                    dtp.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy hh:mm:ss tt";
                    dtp.Size = ogsFormato_Largo_Hora;
                break;
            }
        }
    }
}
