using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIRE_TICKETS
{
    public partial class registroincidencia : Form
    {
        public Boolean bandera;
        public string modulothis;
        public registroincidencia()
        {
            InitializeComponent();
        }

        private void registroincidencia_Load(object sender, EventArgs e)
        {
            bandera = false;
            if (bandera)
                cve_Modulo.Text = modulothis;
        }

        private void cve_Modulo_Click(object sender, EventArgs e)
        {
            

        }

        private void cve_Modulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cve_Modulo.Text == "Ventas")
            {
                cve_SubModulo.Items.Clear();
                cve_SubModulo.Items.Add("Punto de venta");
                cve_SubModulo.Items.Add("Ruteo de ventas");
                cve_SubModulo.Items.Add("Ventas de mayoreo");
            }
            else if (cve_Modulo.Text == "Compras")
            {
                cve_SubModulo.Items.Clear();
                cve_SubModulo.Items.Add("Adquisiciones");
                cve_SubModulo.Items.Add("Proveedores");
                cve_SubModulo.Items.Add("Solicitudes de compra");
            }
            else if (cve_Modulo.Text == "Almacén")
            {
                cve_SubModulo.Items.Clear();
                cve_SubModulo.Items.Add("Catálogo de almacén");
                cve_SubModulo.Items.Add("Transferencia de mercancía interna");
                cve_SubModulo.Items.Add("Existencias");
            }
            else if (cve_Modulo.Text == "Nómina")
            {
                cve_SubModulo.Items.Clear();
                cve_SubModulo.Items.Add("Días festivos");
                cve_SubModulo.Items.Add("Finiquitos y liquidaciones");
                cve_SubModulo.Items.Add("Pago de honorarios");
                cve_SubModulo.Items.Add("Tipos de nómina");
                cve_SubModulo.Items.Add("Vacaciones");
                cve_SubModulo.Items.Add("Inicio Nomisire");
            }
            else if (cve_Modulo.Text == "Utilería de dos capas")
            {
                cve_SubModulo.Items.Clear();
                cve_SubModulo.Items.Add("Reindexado de base de datos");
                cve_SubModulo.Items.Add("Guías contabilizadoras");
                cve_SubModulo.Items.Add("Formatos de migración (Plantillas)");
                cve_SubModulo.Items.Add("Configuración de base de datos (No highpos)");
                cve_SubModulo.Items.Add("Ejecución de scripts");
                cve_SubModulo.Items.Add("Inicio UtilSIRE");
            }
            else if (cve_Modulo.Text == "Utilería de tres capas")
            {
                cve_SubModulo.Items.Clear();
                cve_SubModulo.Items.Add("Configuración de reportes");
                cve_SubModulo.Items.Add("Configuración de parametros");
                cve_SubModulo.Items.Add("Inicio U3C");
                cve_SubModulo.Items.Add("Scripts 3 capas");
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            String mensaje;
            mensaje = (c.registraincidencia(dtpFecha.Value.ToString("yyyy-MM-dd"), txtbrebeinc.Text, DateTime.Now.ToString("hh:mm:ss"), txtdescripcion.Text, 
                cbIncPriori.Text, "1", cve_Modulo.Text, cve_SubModulo.Text, Id_Realase.Text));
            if (mensaje == "Los cambios se guardaron correctamente")
            {
                MessageBox.Show(mensaje);
                txtbrebeinc.Clear();
                txtdescripcion.Clear();
                cve_Modulo.SelectedIndex = 0;
                cve_SubModulo.SelectedIndex = 0;
                cbIncPriori.SelectedIndex = 0;
                Id_Realase.SelectedIndex = 0;
            }
            else
                MessageBox.Show(mensaje);
        }
        public void llenacampos(String breveinc, String descripcion, String modulo, String submodulo, String prioridad, String release, String fecha_alta)
        {
            txtbrebeinc.Text = breveinc;
            txtdescripcion.Text = descripcion;
            txtpriori.Text = prioridad;
            txtrelease.Text = release;
            dtpFecha.Text = fecha_alta;
            txtmodulo.Text = modulo;
            txtsubmodulo.Text = submodulo;
        }
        public void llenacombobox()
        {
            cve_Modulo.Items.Add("Ventas");
            cve_Modulo.Items.Add("Compras");
            cve_Modulo.Items.Add("Almacén");
            cve_Modulo.Items.Add("Nómina");
            cve_Modulo.Items.Add("Utilería de dos capas");
            cve_Modulo.Items.Add("Utilería de tres capas");
            txtbrebeinc.Clear();
            txtdescripcion.Clear();
            cve_Modulo.SelectedIndex = 0;
            cve_SubModulo.SelectedIndex = 0;
            cbIncPriori.SelectedIndex = 0;
            Id_Realase.SelectedIndex = 0;
        }
        public void escondebotones()
        {
            button1.Visible = false;
            btnEntrar.Visible = false;
            cbIncPriori.Visible = false;
            Id_Realase.Visible = false;
            cve_Modulo.Visible = false;
            cve_SubModulo.Visible = false;
            txtmodulo.Visible = true;
            txtpriori.Visible = true;
            txtrelease.Visible = true;
            txtsubmodulo.Visible = true;
            txtbrebeinc.ReadOnly = true;
            txtdescripcion.ReadOnly = true;
            dtpFecha.Enabled = false;
        }
        public void pruebas(String FechaInc, String BreveInc, String Hora, String Descripcion, String IncPriori, String CveClie,
            String Cve_Modulo, String Cve_SubModulo, String Id_Release)
        {
            Conexion c = new Conexion();
            c.registraincidencia(FechaInc, BreveInc, Hora, Descripcion, IncPriori, CveClie, Cve_Modulo, Cve_SubModulo, Id_Release);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult mensaje = new DialogResult();
            mensaje = MessageBox.Show("¿Desea cancelar el registro?", "SIRE Tickets", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                txtbrebeinc.Clear();
                txtdescripcion.Clear();
                cve_Modulo.SelectedIndex = 0;
                cve_SubModulo.SelectedIndex = 0;
                cbIncPriori.SelectedIndex = 0;
                Id_Realase.SelectedIndex = 0;
                txtbrebeinc.Focus();
            }
        }
    }
}
