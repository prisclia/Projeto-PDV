using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class F_GestaoCliente : Form
    {
        public F_GestaoCliente()
        {
            InitializeComponent();
        }

        private void F_GestaoCliente_Load(object sender, EventArgs e)
        {
            dgvCliente.DataSource = Banco.ObterclienteIdNome();
            dgvCliente.Columns[0].Width = 105;
            dgvCliente.Columns[1].Width = 160;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            int contlinhas = dgv.SelectedRows.Count;
            if (contlinhas > 0)
            {
                DataTable dt = new DataTable();
                string vid = dgv.SelectedRows[0].Cells[0].Value.ToString();
                dt = Banco.ObterDadosCliente(vid);
                txtCodigo.Text = dt.Rows[0].Field<Int64>("codigo").ToString();
                txtNome.Text = dt.Rows[0].Field<string>("nome").ToString();
                txtCpf.Text = dt.Rows[0].Field<string>("cpf").ToString();
               
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            F_NovoCliente f_NovoCliente = new F_NovoCliente();
            f_NovoCliente.ShowDialog();
            dgvCliente.DataSource = Banco.ObterUsuariosIdNome();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            int linha = dgvCliente.SelectedRows[0].Index;
            Cliente c = new Cliente();
            c.codigo = Convert.ToInt32(txtCodigo.Text);
            c.nome = txtNome.Text;
            c.cpf = txtCpf.Text;
            Banco.AtualizarCliente(c);
            dgvCliente[1, linha].Value = txtNome.Text;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("CONFIRMA EXCLUSÃO?", "EXCLUIR?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Banco.DeletarUsuario(txtCodigo.Text);
                dgvCliente.Rows.Remove(dgvCliente.CurrentRow);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
