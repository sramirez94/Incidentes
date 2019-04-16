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
    public partial class Form1 : Form
    {
        Conexion c = new Conexion();
        public Boolean bandera;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtnomEmp.Text == "")
                MessageBox.Show("Debe indicar el nombre de la empresa", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (txtEmail.Text == "")
                    MessageBox.Show("Debe indicar un correo electrónico", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (cvSIREVer.Text == "")
                    MessageBox.Show("Debe indicar una versión de SIRE", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (txtnombre.Text == "" && txtPater.Text == "" && txtMater.Text == "")
                    MessageBox.Show("Debe indicar por lo menos el nombre del usuario", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (txtusuario.Text == "")
                MessageBox.Show("Debe indicar el usuario", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBox.Show(c.insertar_empresa(txtnombre.Text, txtPater.Text, txtMater.Text, cbTipoPersona.Text, txtRFC.Text, txtnomEmp.Text, cbGiroEmp.Text, txtCP.Text, txtURL.Text,
                txtCalle.Text, txtEntre_Calle.Text, txtnum_inter.Text, txtNumExt.Text, cbPais.Text, cbEstado.Text, txtCiudad.Text, txtTelefono.Text, txtTel_Ofic.Text, " ",
                txtEmail.Text, txtusuario.Text, txtpass.Text, cvSIREVer.Text, true));
                this.Close();
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion validausuarios = new Conexion();
            login frmlogin = new login();
            if (validausuarios.valida_sihayusuarios() == false)
            {
                MessageBox.Show("No hay usuarios registrados para usar SIRE Tickets, deberá darse de alta", "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (validausuarios.valida_sihayusuarios() && bandera)
            {
                txtnomEmp.Focus();
            }
            else
            {
                frmlogin.ShowDialog();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult mensaje = new DialogResult();
            mensaje = MessageBox.Show("¿Desea cancelar la edición del registro?","SIRE Tickets", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes){
                txtnomEmp.Clear();
                txtCalle.Clear();
                txtCiudad.Clear();
                txtCP.Clear();
                txtEmail.Clear();
                txtEntre_Calle.Clear();
                txtMater.Clear();
                txtnombre.Clear();
                txtnum_inter.Clear();
                txtNumExt.Clear();
                txtpass.Clear();
                txtPater.Clear();
                txtRFC.Clear();
                txtTel_Ofic.Clear();
                txtTelefono.Clear();
                txtURL.Clear();
                txtusuario.Clear();
                cbEstado.Text = "";
                cbGiroEmp.Text = "";
                cbPais.Text = "";
                cbTipoPersona.Text = "";
                txtnomEmp.Focus();
            }
        }
    }
}
