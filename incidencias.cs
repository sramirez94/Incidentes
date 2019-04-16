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
    public partial class incidencias : Form
    {
        string valor;
        Conexion c = new Conexion();
        public incidencias()
        {
            InitializeComponent();
        }

        private void incidencias_Load(object sender, EventArgs e)
        {
            dataGridView1.Focus();
            Conexion c = new Conexion();
            c.poblarincidencias(txtnomax.Text, dataGridView1);
            dataGridView1.Columns[0].HeaderText = "Núm. Inc.";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].HeaderText = "Descripción breve";
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].HeaderText = "Prioridad";
            dataGridView1.Columns[3].HeaderText = "Fecha de reporte";
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[4].HeaderText = "Módulo.";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            registroincidencia nuevainc = new registroincidencia();
            nuevainc.Text = "Registrar una nueva incidencia | SIRE Tickets";
            nuevainc.llenacombobox();
            nuevainc.bandera = true;
            nuevainc.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult mensaje = new DialogResult();
            mensaje = MessageBox.Show("¿Desea eliminar este registro?", "SIRE Tickets", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mensaje == DialogResult.Yes)
            {
                MessageBox.Show(c.eliminainc(valor), "SIRE Tickets", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.poblarincidencias(txtnomax.Text, dataGridView1);
            }
                
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = new DataGridViewRow();
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
                valor = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();                
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            c.poblarincidencias(txtnomax.Text, dataGridView1);
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            String M;
            M = c.pobladetalleinc(valor);
            if (M != "")
                MessageBox.Show(M);
        }
    }
}
