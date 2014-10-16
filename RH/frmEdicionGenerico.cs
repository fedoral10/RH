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
        private List<Label> omglEtiquetas;
        private List<TextBox> omglTextos;
        private List<NumericUpDown> omglNumericos;
        private List<DateTimePicker> omglFechas;
        private List<Control> omglControles;
        public frmEdicionGenerico()
        {
            this.omglEtiquetas = new List<Label>();
            this.omglTextos = new List<TextBox>();
            this.omglNumericos = new List<NumericUpDown>();
            this.omglFechas = new List<DateTimePicker>();
            this.omglControles = new List<Control>();
            InitializeComponent();
        }
        public void AgregarControl(PropiedadCadenaTexto control)
        {
            this.omglEtiquetas.Add(control.omgEtiqueta);
            this.omglTextos.Add(control.omgCuadro);
            Agregar(control);
        }
        public void AgregarControl(PropiedadNumerica control)
        {
            omglEtiquetas.Add(control.omgEtiqueta);
            this.omglNumericos.Add(control.omgCuadro);
            Agregar(control);
        }
        public void AgregarControl(PropiedadFecha control)
        {
            omglEtiquetas.Add(control.omgEtiqueta);
            this.omglFechas.Add(control.omgCuadro);
            Agregar(control);
        }
        private void Agregar(Control control)
        {
            this.ogpPanelPrincipal.Controls.Add(control);
            this.omglControles.Add(control);
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
            foreach (Label lab in this.omglEtiquetas)
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
            foreach (Label lab in this.omglEtiquetas)
            {
                lab.Size = anchomax;
                lab.TextAlign = ContentAlignment.MiddleLeft;
                
            }
            foreach (TextBox tex in this.omglTextos)
            {
                tex.Location = new Point(anchomax.Width, 1);
                text = tex.Size;
                tams_cuadros.Add(tex.Size);
            }
            foreach (DateTimePicker dat in this.omglFechas)
            {
                dat.Location = new Point(anchomax.Width, 1);
                tams_cuadros.Add(dat.Size);
            }
            foreach (NumericUpDown num in this.omglNumericos)
            {
                num.Location = new Point(anchomax.Width, 1);
                tams_cuadros.Add(num.Size);
            }
            var x = (from tam in tams_cuadros
                     select tam.Width).Max();
            foreach (Control con in this.omglControles)
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
        //string ogsNombre;
        public NumericUpDown omgCuadroNumerico;
        public TextBox omgCuadroTexto;
        

        public enum TIPO_FECHA { FECHA_CORTA, FECHA_LARGA, FECHA_CORTA_HORA, FECHA_LARGA_HORA }

        Size ogsFormato_Largo = new Size(200, 20);//long
        Size ogsFormato_Corto = new Size(80, 20);//short
        Size ogsFormato_Largo_Hora = new Size(270, 20);//long time
        Size ogsFormato_Corto_Hora = new Size(150, 20);//short time


        public DateTimePicker omgCuadro;
        public Label omgEtiqueta;

        private void InicializaValoresFecha(TIPO_FECHA tipo = TIPO_FECHA.FECHA_CORTA, DateTime valor_inicial = new DateTime(), string texto_etiqueta = "Fecha: ")
        {
            valor_inicial = DateTime.Now;
            this.omgCuadro = new DateTimePicker();
            this.omgEtiqueta = new Label();
            this.Cambia_Formato(this.omgCuadro, tipo);
            this.omgCuadro.Value = valor_inicial;
            this.omgEtiqueta.Text = texto_etiqueta;
            Size textSize = TextRenderer.MeasureText(omgEtiqueta.Text, omgEtiqueta.Font);
            this.omgEtiqueta.Size = new Size(textSize.Width, omgCuadro.Height);
            this.omgEtiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(omgEtiqueta);
            this.Controls.Add(omgCuadro);
            this.omgCuadro.Location = new Point(omgEtiqueta.Width, 1);

            this.Size = new Size(omgCuadro.Width + omgEtiqueta.Width + 10, omgCuadro.Height);
        }
        private void InicializaValoresNumerico(TIPO_NUMERICA tipo, decimal valor_inicial = 0, int cantidad_decimales = 0, decimal maximo = 99999999999999999, decimal minimo = -99999999999999999)
        {
            if (tipo == TIPO_NUMERICA.FLOTANTE && cantidad_decimales == 0)
            {
                this.omgCuadroNumerico.DecimalPlaces = 2;
            }
            if (tipo == TIPO_NUMERICA.ENTERA)
            {
                this.omgCuadroNumerico.DecimalPlaces = 0;
            }
            if (tipo == TIPO_NUMERICA.FLOTANTE && cantidad_decimales != 0)
            {
                this.omgCuadroNumerico.DecimalPlaces = cantidad_decimales;
            }
            this.omgCuadroNumerico.Maximum = maximo;
            this.omgCuadroNumerico.Minimum = minimo;
            this.omgCuadroNumerico.Value = valor_inicial;
        }
        public void InicializaValoresTexto(TIPO_TEXTO tipo, int ancho = 100, int alto = 20, string texto_inicial = "", string texto_etiqueta = "")
        {
            this.omgCuadroTexto = new TextBox();
            this.omgEtiqueta = new Label();
            this.omgCuadroTexto.Size = new Size(ancho, alto);
            this.omgCuadroTexto.Text = texto_inicial;
            this.omgEtiqueta.Text = texto_etiqueta;
            if (tipo == TIPO_TEXTO.LINEA_UNICA)
            {
                this.omgCuadroTexto.Multiline = false;
            }
            else
            {
                this.omgCuadroTexto.Multiline = true;
            }
            if (string.IsNullOrEmpty(texto_etiqueta))
            {
                this.omgEtiqueta.Text = "Cadena: ";
            }
            else
            {
                this.omgEtiqueta.Text = texto_etiqueta + ": ";
            }

            this.Controls.Add(omgEtiqueta);
            this.Controls.Add(omgCuadroTexto);
            Alinear();
        }
        private void Cambia_Formato(DateTimePicker dtp, TIPO_FECHA tipo)
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
        private void Alinear()
        {
            Size olTextSize = TextRenderer.MeasureText(omgEtiqueta.Text, omgEtiqueta.Font);
            //this.etiqueta.AutoSize = false;
            this.omgEtiqueta.Size = new Size(olTextSize.Width, omgCuadroTexto.Height);
            this.omgEtiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.omgCuadroTexto.Location = new Point(omgEtiqueta.Width, 1);

            this.Size = new Size(omgCuadroTexto.Width + omgEtiqueta.Width + 10, omgCuadroTexto.Height);
        }
    }
     public class PropiedadNumerica : UserControl
    {
        
        public enum TIPO {FLOTANTE,ENTERA}
        string ogsNombre;
        public NumericUpDown omgCuadro;
        public Label omgEtiqueta;

        private void InicializarObjetos()
        {
            this.omgCuadro = new NumericUpDown();
            this.omgEtiqueta = new Label();
            this.omgCuadro.Name = "cuadro";
            this.omgEtiqueta.Name = "etiqueta";

            if (string.IsNullOrEmpty(this.Nombre))
            {
                this.omgEtiqueta.Text = "Numerico: ";
            }
            else
            {
                this.omgEtiqueta.Text = this.Nombre + ": ";
            }
            Size textSize = TextRenderer.MeasureText(omgEtiqueta.Text, omgEtiqueta.Font);
            this.omgEtiqueta.Size = new Size(textSize.Width,omgCuadro.Height);
            this.omgEtiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(omgEtiqueta);
            this.Controls.Add(omgCuadro);
            this.omgCuadro.Location = new Point(omgEtiqueta.Width, 1);
            
            this.Size = new Size(omgCuadro.Width + omgEtiqueta.Width + 10, omgCuadro.Height);
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
                this.omgCuadro.DecimalPlaces = 2;
            }
            if(tipo == TIPO.ENTERA)
            {
                this.omgCuadro.DecimalPlaces = 0;
            }
            if(tipo == TIPO.FLOTANTE && cantidad_decimales != 0)
            {
                this.omgCuadro.DecimalPlaces = cantidad_decimales;
            }
            this.omgCuadro.Maximum = maximo;
            this.omgCuadro.Minimum = minimo;
            this.omgCuadro.Value = valor_inicial;
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
        public TextBox omgCuadro;
        public Label omgEtiqueta;
        public void InicializaValores(TIPO tipo,int ancho=100, int alto=20,string texto_inicial ="",string texto_etiqueta="")
        {
            this.omgCuadro = new TextBox();
            this.omgEtiqueta = new Label();
            this.omgCuadro.Size = new Size(ancho, alto);
            this.omgCuadro.Text = texto_inicial;
            this.omgEtiqueta.Text = texto_etiqueta;
            if (tipo == TIPO.LINEA_UNICA)
            {
                this.omgCuadro.Multiline = false;
            }
            else
            {
                this.omgCuadro.Multiline = true;
            }
            if (string.IsNullOrEmpty(texto_etiqueta))
            {
                this.omgEtiqueta.Text = "Cadena: ";
            }
            else
            {
                this.omgEtiqueta.Text = texto_etiqueta + ": ";
            }
           
            this.Controls.Add(omgEtiqueta);
            this.Controls.Add(omgCuadro);
            alinear();
        }

        private void alinear()
        {
            Size omlTextSize = TextRenderer.MeasureText(omgEtiqueta.Text, omgEtiqueta.Font);
            //this.etiqueta.AutoSize = false;
            this.omgEtiqueta.Size = new Size(omlTextSize.Width, omgCuadro.Height);
            this.omgEtiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.omgCuadro.Location = new Point(omgEtiqueta.Width, 1);

            this.Size = new Size(omgCuadro.Width + omgEtiqueta.Width + 10, omgCuadro.Height);
        }
        
        public PropiedadCadenaTexto()
        {
            InicializaValores(TIPO.LINEA_UNICA);
            this.omgEtiqueta.TextChanged += etiqueta_TextChanged;
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


        public DateTimePicker omgCuadro;
        public Label omgEtiqueta;

        private void InicializaValores(TIPO tipo = TIPO.FECHA_CORTA, DateTime valor_inicial=new DateTime(),string texto_etiqueta="Fecha: ")
        {
            valor_inicial = DateTime.Now;
            this.omgCuadro = new DateTimePicker();
            this.omgEtiqueta = new Label();
            cambia_formato(this.omgCuadro, tipo);
            this.omgCuadro.Value = valor_inicial;
            this.omgEtiqueta.Text = texto_etiqueta;
            Size textSize = TextRenderer.MeasureText(omgEtiqueta.Text, omgEtiqueta.Font);
            this.omgEtiqueta.Size = new Size(textSize.Width, omgCuadro.Height);
            this.omgEtiqueta.TextAlign = ContentAlignment.MiddleLeft;
            this.Controls.Add(omgEtiqueta);
            this.Controls.Add(omgCuadro);
            this.omgCuadro.Location = new Point(omgEtiqueta.Width, 1);

            this.Size = new Size(omgCuadro.Width + omgEtiqueta.Width + 10, omgCuadro.Height);
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
