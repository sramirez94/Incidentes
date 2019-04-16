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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Conexion c = new Conexion();
            Principal frmprincipal = new Principal();
            if (String.IsNullOrEmpty(txtUsuario.Text) && String.IsNullOrEmpty(txtPass.Text)) {
               MessageBox.Show("No ha indicado un usuario y contraseña", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
               txtUsuario.Focus();
               return;
            }
            if (c.login(txtUsuario.Text, txtPass.Text))
            {
                frmprincipal.Text = "SIRE Sistema Integrador de Recursos Empresariales módulo de reporte de incidencias SIRE Tickets";
                frmprincipal.ShowDialog();
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error de usuario y/o contraseña", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPass.Clear();
                txtUsuario.Clear();
                txtUsuario.Focus();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult mensaje = new DialogResult();
            mensaje = MessageBox.Show("¿Desea salir?", "SIRE Tickets", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
                Application.Exit();
        }
    }
}
