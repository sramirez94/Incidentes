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
    public partial class Principal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            incidencias frmincidencias = new incidencias();
            frmincidencias.Text = "Registro de incidencias reportadas";
            frmincidencias.MdiParent = this;
            frmincidencias.Show();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            registroincidencia frmincidencias = new registroincidencia();
            frmincidencias.Text = "Registro de nueva incidencia";
            frmincidencias.llenacombobox();
            frmincidencias.MdiParent = this;
            frmincidencias.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            buscarinc busqueda = new buscarinc();
            busqueda.MdiParent = this;
            busqueda.Text = "Buscar incidencia";
            busqueda.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form1 registro = new Form1();
            registro.Text = "Registrar nuevo usuario";
            registro.bandera = true;
            registro.MdiParent = this;
            registro.Show();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult mensaje = new DialogResult();
            mensaje = MessageBox.Show("¿Desea salir de SIRE Tickets?", "SIRE Tickets", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje != DialogResult.Yes)
                e.Cancel = true;
            else
                return;
        }
    }
}
