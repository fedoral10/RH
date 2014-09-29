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
        private List<Label> etiquetas;
        private List<TextBox> textos;
        private List<NumericUpDown> numericos;
        private List<DateTimePicker> fechas;
        private List<Control> controles;
        public frmEdicionGenerico()
        {
            this.etiquetas = new List<Label>();
            this.textos = new List<TextBox>();
            this.numericos = new List<NumericUpDown>();
            this.fechas = new List<DateTimePicker>();
            this.controles = new List<Control>();
            InitializeComponent();
        }
        public void AgregarControl(PropiedadCadenaTexto control)
        {
            this.etiquetas.Add(control.etiqueta);
            this.textos.Add(control.cuadro);
            Agregar(control);
        }
        public void AgregarControl(PropiedadNumerica control)
        {
            etiquetas.Add(control.etiqueta);
            this.numericos.Add(control.cuadro);
            Agregar(control);
        }
        public void AgregarControl(PropiedadFecha control)
        {
            etiquetas.Add(control.etiqueta);
            this.fechas.Add(control.cuadro);
            Agregar(control);
        }
        private void Agregar(Control control)
        {
            this.ogpPanelPrincipal.Controls.Add(control);
            this.controles.Add(control);
            this.ogpPanelPrincipal.Refresh();
            this.ogpPanelPrincipal.Update();
        }
        public void EliminaControl(Control control)
        {
            this.ogpPanelPrincipal.Controls.Remove(control);
            this.ogpPanelPrincipal.Refresh();
            this.ogpPanelPrincipal.Update();
        }
        public PropiedadNumerica ObtienePropiedadNumerica(string nombre)
        {
            Control[] controles = this.ogpPanelPrincipal.Controls.Find(nombre, true);
            PropiedadNumerica control=null;
            if (controles.Length > 0)
            {
                control = (PropiedadNumerica)controles[0];
            }
            else
            {
                throw new Exception("No se ha encontrado la propiedad");
            }
            return control;
        }

        public void Alinear()
        {
            List<Size> tams_labels = new List<Size>();
            List<Size> tams_cuadros = new List<Size>();
            foreach (Label lab in this.etiquetas)
            {
                tams_labels.Add(TextRenderer.MeasureText(lab.Text, lab.Font));
            }
            Size text  = new Size();
            Size anchomax = new Size();
            foreach (Size tami in tams_labels)
            {
                    if (tami.Width >= anchomax.Width)
                    {
                        anchomax = tami;
                    }

            }
            foreach (Label lab in this.etiquetas)
            {
                lab.Size = anchomax;
                lab.TextAlign = ContentAlignment.MiddleLeft;
                
            }
            foreach (TextBox tex in this.textos)
            {
                tex.Location = new Point(anchomax.Width, 1);
                text = tex.Size;
                tams_cuadros.Add(tex.Size);
            }
            foreach (DateTimePicker dat in this.fechas)
            {
                dat.Location = new Point(anchomax.Width, 1);
                tams_cuadros.Add(dat.Size);
            }
            foreach (NumericUpDown num in this.numericos)
            {
                num.Location = new Point(anchomax.Width, 1);
                tams_cuadros.Add(num.Size);
            }
            var x = (from tam in tams_cuadros
                     select tam.Width).Max();
            foreach (Control con in this.controles)
            {
                con.Size = new Size(anchomax.Width+ x, text.Height);
            }
        }
        private void frmEdicionGenerico_Load(object sender, EventArgs e)
        {
            Alinear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    public class PropiedadGenerica : UserControl
    {
        public enum TIPO_NUMERICA {FLOTANTE,ENTERA}
        public enum TIPO_TEXTO { MULTILINEA, LINEA_UNICA }
        string ogsNombre;
        public NumericUpDown cuadro_numerico;
        public TextBox cuadro_texto;
        

        public enum TIPO_FECHA { FECHA_CORTA, FECHA_LARGA, FECHA_CORTA_HORA, FECHA_LARGA_HORA }

        Size ogsFormato_Largo = new Size(200, 20);//long
        Size ogsFormato_Corto = new Size(80, 20);//short
        Size ogsFormato_Largo_Hora = new Size(270, 20);//long time
        Size ogsFormato_Corto_Hora = new Size(150, 20);//short time


        public DateTimePicker cuadro;
        public Label etiqueta;

        private void InicializaValoresFecha(TIPO_FECHA tipo = TIPO_FECHA.FECHA_CORTA, DateTime valor_inicial = new DateTime(), string texto_etiqueta = "Fecha: ")
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
        private void InicializaValoresNumerico(TIPO_NUMERICA tipo, decimal valor_inicial = 0, int cantidad_decimales = 0, decimal maximo = 99999999999999999, decimal minimo = -99999999999999999)
        {
            if (tipo == TIPO_NUMERICA.FLOTANTE && cantidad_decimales == 0)
            {
                this.cuadro_numerico.DecimalPlaces = 2;
            }
            if (tipo == TIPO_NUMERICA.ENTERA)
            {
                this.cuadro_numerico.DecimalPlaces = 0;
            }
            if (tipo == TIPO_NUMERICA.FLOTANTE && cantidad_decimales != 0)
            {
                this.cuadro_numerico.DecimalPlaces = cantidad_decimales;
            }
            this.cuadro_numerico.Maximum = maximo;
            this.cuadro_numerico.Minimum = minimo;
            this.cuadro_numerico.Value = valor_inicial;
        }
        public void InicializaValoresTexto(TIPO_TEXTO tipo, int ancho = 100, int alto = 20, string texto_inicial = "", string texto_etiqueta = "")
        {
            this.cuadro_texto = new TextBox();
            this.etiqueta = new Label();
            this.cuadro_texto.Size = new Size(ancho, alto);
            this.cuadro_texto.Text = texto_inicial;
            this.etiqueta.Text = texto_etiqueta;
            if (tipo == TIPO_TEXTO.LINEA_UNICA)
            {
                this.cuadro_texto.Multiline = false;
            }
            else
            {
                this.cuadro_texto.Multiline = true;
            }
            if (string.IsNullOrEmpty(texto_etiqueta))
            {
                this.etiqueta.Text = "Cadena: ";
            }
            else
            {
                this.etiqueta.Text = texto_etiqueta + ": ";
            }

            this.Controls.Add(etiqueta);
            this.Controls.Add(cuadro_texto);
            alinear();
        }
        private void cambia_formato(DateTimePicker dtp, TIPO_FECHA tipo)
        {

            switch (tipo)
            {
                case TIPO_FECHA.FECHA_CORTA:
                    dtp.Format = DateTimePickerFormat.Short;
                    dtp.Size = ogsFormato_Corto;
                    break;
                case TIPO_FECHA.FECHA_LARGA:
                    dtp.Format = DateTimePickerFormat.Long;
                    dtp.Size = ogsFormato_Largo;
                    break;
                case TIPO_FECHA.FECHA_CORTA_HORA:
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
                    dtp.Size = ogsFormato_Corto_Hora;
                    break;
                case TIPO_FECHA.FECHA_LARGA_HORA:
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dddd, dd 'de' MMMM 'de' yyyy hh:mm:ss tt";
                    dtp.Size = ogsFormato_Largo_Hora;
                    break;
            }
        }
        private void alinear()
        {
            Size textSize = TextRenderer.MeasureText(etiqueta.Text, etiqueta.Font);
            //this.etiqueta.AutoSize = false;
            this.etiqueta.Size = new Size(textSize.Width, cuadro_texto.Height);
            this.etiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.cuadro_texto.Location = new Point(etiqueta.Width, 1);

            this.Size = new Size(cuadro_texto.Width + etiqueta.Width + 10, cuadro_texto.Height);
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
            
        }
        public PropiedadNumerica(string nombre, TIPO tipo, decimal valor_inicial)
        {
            this.Nombre = nombre;
            InicializarObjetos();
            InicializaValores(tipo, valor_inicial);

        }
        public PropiedadNumerica(string nombre,TIPO tipo, decimal valor_inicial, int cantidad_decimales)
        {
            this.Nombre = nombre;
            InicializarObjetos();
            InicializaValores(tipo, valor_inicial, cantidad_decimales);

        }
        public PropiedadNumerica(string nombre, TIPO tipo, decimal minimo, decimal maximo)
        {
            this.Nombre = nombre;
            InicializarObjetos();
            InicializaValores(tipo, 0,0, maximo, minimo);

        }
        public PropiedadNumerica(string nombre, TIPO tipo, decimal minimo, decimal maximo, decimal valor_inicial)
        {
            this.Nombre = nombre;
            InicializaValores(tipo, valor_inicial, 0, maximo, minimo);
            
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
           
            this.Controls.Add(etiqueta);
            this.Controls.Add(cuadro);
            alinear();
        }

        private void alinear()
        {
            Size textSize = TextRenderer.MeasureText(etiqueta.Text, etiqueta.Font);
            //this.etiqueta.AutoSize = false;
            this.etiqueta.Size = new Size(textSize.Width, cuadro.Height);
            this.etiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.cuadro.Location = new Point(etiqueta.Width, 1);

            this.Size = new Size(cuadro.Width + etiqueta.Width + 10, cuadro.Height);
        }
        
        public PropiedadCadenaTexto()
        {
            InicializaValores(TIPO.LINEA_UNICA);
            this.etiqueta.TextChanged += etiqueta_TextChanged;
        }

        void etiqueta_TextChanged(object sender, EventArgs e)
        {
            alinear();
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
